#include <stdio.h>
#include<pthread.h>

const int n=4;
double A[4][4], b[4],c[4];


 void* f(void *arg){
 double s;
 int i,j,iStart,iFinish;

 int k=*((int*)arg);
printf("k=%d\n",k);
 if(k) {iStart=n/2;iFinish=n;}
 else {iStart=0;iFinish=n/2; }

   for ( i = iStart; i < iFinish; i++ ) {
       s=0.0;
       for ( j = 0; j < n; j++ )
       {
        s+=A[i][j]*b[j];
       }
       c[i]=s;
    }

 return NULL;

 }


int main()
{
  int i, j;


  for ( i = 0; i < n; i++ ) {
    b[i]=1.0;
    for ( j = 0; j < n; j++ )
      A[i][j] = i;
      }

  printf( "A:\n" );
  for ( i = 0; i < 4; i++ ) {
    for ( j = 0; j < n; j++ )
    {
        printf( "%f  ", A[i][j] );
       
    }
    printf( "\n" );
  }
  //------------------------
  printf( "b:\n" );
  for ( i = 0; i < n; i++ ) {
  	printf("%f ",b[i]);
  	printf( "\n" );
  }

  pthread_t th1,th2;
  int numThread1=0;
  pthread_create(&th1,NULL,f,(void*)(&numThread1));
 int numThread2=1;
  pthread_create(&th2,NULL,f,(void*)(&numThread2));
  pthread_join(th1,NULL);
  pthread_join(th2,NULL);






      printf( "c=A*b:\n" );
        for ( j = 0; j < n; j++ )
            printf( "%f  ", c[j] );
     printf( "\n" );

      getchar();
}

