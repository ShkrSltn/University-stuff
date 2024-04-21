#include <stdio.h>
#include "omp.h"

static long MULTIPLIER = 1366;
static long ADDEND = 150889;
static long PMOD = 714025;
long random_last = 0;
double random ()
{
long random_next;
      random_next = (MULTIPLIER * random_last + ADDEND)% PMOD;
      random_last = random_next;
      return ((double)random_next/(double)PMOD);
}

static long num_trials = 100000000;
void main ()
{
long i;
long Ncirc = 0;
double pi, x, y;
double r = 1.0; // radius of circle. Side of squrare is 2*r
 //seed(0,-r, r); // The circle and square are centered at the origin
 #pragma omp parallel for private (x, y) reduction (+:Ncirc)
for(i=0;i<num_trials; i++)
{
x = random();
y = random();
if (( x*x + y*y) <= r*r) Ncirc++;
}
pi = 4.0 * ((double)Ncirc/(double)num_trials);
printf("\n %ld trials, pi is %f \n",num_trials, pi);
}

