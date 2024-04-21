
#include <stdio.h>
#include "mpi.h"


#define NN 20


int main(int argc, char **argv)
{
	int a[NN] = { 1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,99 };
	int i, size, ns, nf;
	int myrank, ranksize;
	int lmax, max;
	MPI_Status status;
	MPI_Init(&argc, &argv);
	MPI_Comm_rank(MPI_COMM_WORLD, &myrank);
	MPI_Comm_size(MPI_COMM_WORLD, &ranksize);
	size = NN / ranksize;
	ns = size * myrank;
	nf = ns + size;
	if (myrank == (ranksize - 1))nf = NN;
	lmax = a[ns];
	for (i = ns;i < nf;i++)
		if (lmax < a[i])lmax = a[i];
	printf("My rank = %d Local max =%d\n", myrank, lmax);
	if (myrank == 0) {
		max = lmax;
		for (i = 1;i < ranksize;i++) {
			MPI_Recv(&lmax, 1, MPI_INT, i, 99, MPI_COMM_WORLD, &status);
			if (max < lmax)max = lmax;
		}
		printf("Master: max= %d\n", max);
	}
	else
		MPI_Send(&lmax, 1, MPI_INT, 0, 99, MPI_COMM_WORLD);
	MPI_Finalize();
}

