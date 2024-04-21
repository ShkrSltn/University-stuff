#include <stdio.h>
#include <stdlib.h>
#include "mpi.h"
void bubble_sort (int *arr, int size ){ 
    // Сортировка массива пузырьком
    int i,j,temp;
    for (i = 0; i < size - 1; i++) {
        for (j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                // меняем элементы местами
                temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}
int Compute_partner(int phase, int myrank, int ranksize)
{
        int partner;
	if (phase % 2 == 0) 
		if (myrank % 2 != 0) 
			partner = myrank - 1;
		else
			partner = myrank + 1;
	else 
		if (myrank % 2 != 0 )
			partner = myrank + 1;
		else 
			partner = myrank - 1;
	if(partner == -1 || partner == ranksize)
		partner = MPI_PROC_NULL;
        return partner; 
}

void main(int argc,char **argv){
   int n=5;
   int i, partner;
   int a[n], b[n], c[2*n];
   int myrank, ranksize;
   MPI_Status status;
   MPI_Init(&argc,&argv);
   MPI_Comm_rank(MPI_COMM_WORLD, &myrank);
   MPI_Comm_size(MPI_COMM_WORLD, &ranksize);
   srand(myrank+1);
   for(i=0;i<n; i++)
   {
	a[i]=rand()%100;
   }
   bubble_sort(a,n);

   if (myrank==0)
   {	
     printf("After local sort:\n");
     printf("\nMyRank = %d\n", myrank);
     for(i=0;i<n; i++)
	printf(" %d ",a[i]);
     printf("\n");
     int ii;
     for(ii=1;ii<ranksize; ii++)
     {        MPI_Recv(b,n,MPI_INT,ii,99,MPI_COMM_WORLD,&status);
              printf("\nMyRank = %d\n", ii);
              for(i=0;i<n; i++)
		  printf(" %d ",b[i]);
      	      printf("\n");
     }
   }
   else MPI_Send(a, n,MPI_INT,0,99,MPI_COMM_WORLD);
   int phase;
   for (phase = 0; phase < ranksize; phase++) {
     partner = Compute_partner(phase, myrank, ranksize);
     if(partner != MPI_PROC_NULL)
     {
        MPI_Send(a, n,MPI_INT,partner,99,MPI_COMM_WORLD);
        MPI_Recv(b,n,MPI_INT,partner,99,MPI_COMM_WORLD,&status);
	for(i=0; i<n; i++)
	{
		c[i]=a[i];
		c[n+i]=b[i];
	}
	bubble_sort(c,2*n);
        if(myrank < partner)
        {
          // Keep_smaller

          for(i=0; i<n; i++)
          {
		a[i] = c[i];
		b[i] = c[n+i];
	  }
        }
	else
        {

     // Keep_bigger  

          for(i=0; i<n; i++)
          {
	    a[i] = c[n+i];
	    b[i] = c[i];
	  }
	 }
       
    }
}
// Получить слева  передать направо и печатать
/*int nleft=myrank-1;
int nright=myrank+1;
	if(nleft<0)
	nleft = MPI_PROC_NULL;

	if(nright>=ranksize)
	nright = MPI_PROC_NULL;



MPI_Sendrecv(a, 1, MPI_INT,
                nright, 99,
                b, 1, MPI_INT,
                nleft, 99,
                MPI_COMM_WORLD, &status);
*/

        MPI_Send(a, n,MPI_INT,partner,99,MPI_COMM_WORLD);
        MPI_Recv(b,n,MPI_INT,partner,99,MPI_COMM_WORLD,&status);

if (myrank==0)
{
   printf("\n\nFinish sort:\n");	
   printf("\nMyRank = %d\n", myrank);
   for(i=0;i<n; i++)printf(" %d ",a[i]);
   printf("\n");
   int ii;
   for(ii=1;ii<ranksize; ii++)
   {        MPI_Recv(a,n,MPI_INT,ii,99,MPI_COMM_WORLD,&status);
            printf("\nMyRank = %d\n", ii);
            for(i=0;i<n; i++)
		printf(" %d ",a[i]);
      	    printf("\n");
   }
}
else MPI_Send(a, n,MPI_INT,0,99,MPI_COMM_WORLD);
MPI_Finalize();

}

