#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>

int f(int* x ){return *x;}

pthread_cond_t condBarrier;
pthread_mutex_t mutexBarrier;

int n = 0;
int nThreads = 4;

/*struct xy {
	int* x;
	int* y;
};*/

void barrier() {
	n++;
	if (n < nThreads) {
		pthread_mutex_lock(&mutexBarrier);
		pthread_cond_wait(&condBarrier, &mutexBarrier);
		pthread_mutex_unlock(&mutexBarrier);
	} else {
		n = 0;
		pthread_cond_broadcast(&condBarrier);
	}
}

void* thread_func(void* arg) {
	//struct xy xy1 = *((struct xy*) arg);
	int* y = (int*) arg;
	int x;
	while(1) {
		x = rand() % 50;
		*y = f(&x);
		printf("Thread #%d computed:%d\n", (int)pthread_self(), *y);
		barrier();
		barrier();
	}
	//return &y;
}

int main()
{  
	int /*x1,x2,x3,*/y1,y2,y3;
	int res;
	/*struct xy xy1, xy2, xy3;
	xy1.x = &x1; xy1.y = &y1;
	xy2.x = &x2; xy2.y = &y2;
	xy3.x = &x3; xy3.y = &y3;*/
	pthread_t t1, t2, t3;
	pthread_create(&t1, NULL, thread_func, &y1);
	pthread_create(&t2, NULL, thread_func, &y2);
	pthread_create(&t3, NULL, thread_func, &y3);
	while(1) {
		//x1=rand() % 50;
		//x2=rand() % 50;
		//x3=rand() % 50;
        
		barrier();
		res = y1+y2+y3;
		printf("Hello, World! Res is: %d\n", res);
        
		if(res > 130) {
			break;
		} 
		printf("Press 'Enter' to continue\n");
		getchar();
		barrier();
             
	}
	return 0;
}
