#include <stdio.h>
#include "omp.h"
// Вычисление числа pi
double f(double y) {return(4.0/(1.0+y*y));}
int main()
{
int _threads;
    printf("Введите кол-во потоков:");
    scanf("%d", &_threads);
    long int n = 10000;
    printf("Введите n:");
    scanf("%ld", &n);
double w, x, sum, pi;
long int i;


w = 1.0/n;
sum = 0.0;
double f_time,s_time;
s_time = omp_get_wtime();

for(i=0; i < n; i++)
{
x = w*(i-0.5);
sum = sum + f(x);
}
pi = w*sum;
f_time = omp_get_wtime();
printf("n= %ld pi = %f time = %f \n", n,pi,f_time - s_time);


s_time = omp_get_wtime();
sum = 0.0;
#pragma omp parallel for private(x) shared(w) reduction(+:sum) num_threads(_threads)
for(i=0; i < n; i++)
{
x = w*(i-0.5);
sum = sum + f(x);
}
pi = w*sum;
f_time = omp_get_wtime();
printf("parallel n= %ld pi = %f time = %f \n", n,pi,f_time - s_time);
}

