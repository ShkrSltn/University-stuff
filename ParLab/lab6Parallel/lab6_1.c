#include <stdio.h>
#include "omp.h"

static long MULTIPLIER = 1366;
static long ADDEND = 150889;
static long PMOD = 714025;
long random_last = 0;
#pragma omp threadprivate(random_last)
double random()
{
	long random_next;
	random_next = (MULTIPLIER * random_last + ADDEND) % PMOD;
	random_last = random_next;
	return ((double)random_next / (double)PMOD);
}

    
void main()
{
	long num_trials;
 	   printf("Введите кол-во шагов:");
    	   scanf("%ld", &num_trials);
	long i;
	long Ncirc = 0;
	double pi, x, y;
	double r = 1.0; // radius of circle. Side of squrare is 2*r
	 //seed(0,-r, r); // The circle and square are centered at the origin
	unsigned long long pseed[10], iseed;
	int n;
	printf("Введите кол-во потоков:");
    	   scanf("%d", &n);
	#pragma omp parallel num_threads(n)
	{
#pragma omp single
	{ int nthreads = omp_get_num_threads();
	iseed = PMOD / MULTIPLIER; // just pick a seed
	pseed[0] = iseed;
	int mult_n = MULTIPLIER;
	for (i = 1; i < nthreads; ++i)
	{
	iseed = (unsigned long long)((MULTIPLIER * iseed) % PMOD);
	pseed[i] = iseed;
	mult_n = (mult_n * MULTIPLIER) % PMOD;
	}
	}
	random_last = (unsigned long long) pseed[omp_get_thread_num()];


	#pragma omp for private (x, y) reduction (+:Ncirc) 
	for (i = 0;i < num_trials; i++)
	{
		x = random();
		y = random();
		if ((x*x + y * y) <= r * r) Ncirc++;
	}
	}
	pi = 4.0 * ((double)Ncirc / (double)num_trials);
	printf("\n %ld trials, pi is %f \n", num_trials, pi);
	char c = getchar();
}
