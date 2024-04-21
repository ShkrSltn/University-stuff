#include <malloc.h>
#include <pthread.h> 
#include  <semaphore.h>
//#include <math.h>
struct  job  {
	struct job* next;
	int n;
};
struct job* job_queue;
/* Исключающий семафор, защищающий очередь. */ 
pthread_mutex_t job_queue_mutex = PTHREAD_MUTEX_INITIALIZER;
/*Потоковый семафор, подсчитывающий число заданий 
в очереди. */ 
sem_t job_queue_count;

/* Начальная инициализация очереди. */
void initialize_job_queue () {
	/* Вначале очередь пуста. */
	job_queue = NULL;
	/* Устанавливаем начальное значение счетчика 
		семафора равным 0. */
	sem_init (&job_queue_count, 0, 0); 
}

void process_job(struct job* next_job) {
	int n = next_job->n;
	int i;
	for (i = n-1; i > 1; i--) {
		double s = i / 2;
		int j;
		int flag = 0;
		for (j = 2; j <= s; j++) {
			if (i % j == 0) {
				flag = 1;
				break;
			}
		}
		if (flag == 0) break;
	}
	printf("Поток #%d, полученное число:%d, результат:%d\n", (int)pthread_self(), n, i);
}

/* Обработка заданий до тех пор, 
пока очередь не опустеет. */
void* thread_function (void* arg) {
	struct job* next_job;
	while (1) {
		sem_wait(&job_queue_count);
		/* Захват исключающего семафора,
 			защищающего очередь. */
		pthread_mutex_lock(&job_queue_mutex);
		next_job = job_queue; 
		/* Удаляем задание из списка. */ 
		job_queue = job_queue->next; 
		/* Освобождаем исключающий семафор,
 			так как работа с очередью окончена. */ 
 		pthread_mutex_unlock (&job_queue_mutex);
		/* Выполняем задание. */
		process_job(next_job);
		/* Очистка. */
		free(next_job);
	}
	return NULL; 
}

/* Добавление нового задания в начало очереди. */
void enqueue_job(int n) {
	struct job* new_job;
	/* Выделение памяти для нового объекта задания. */
	new_job = (struct job*) malloc (sizeof (struct job)); 
	/* Заполнение остальных полей структуры JOB... */
	new_job->n=n;
	/* Захватываем исключающий семафор, прежде чем 
		обратиться к очереди. */
	pthread_mutex_lock (&job_queue_mutex); 
	/* Помещаем новое задание в начало очереди. */
	new_job->next = job_queue; job_queue = new_job;
	/* Устанавливаем семафор, сообщая о том, что в 
		очереди появилось новое задание. 
		Если есть потоки, заблокированные в ожидании 
		семафора, один из них будет разблокирован и 
		обработает задание. */
	sem_post(&job_queue_count);
	/*  Освобождаем исключающий  семафор.   */
	pthread_mutex_unlock(&job_queue_mutex);
}

int main() {
	initialize_job_queue();
	pthread_t t;
	int i;
	for (i = 0; i < 3; i++) {
		pthread_create(&t, NULL, thread_function, NULL);
	}
	FILE *pfile;
	pfile = fopen("flab3in.txt", "r");
	int n;
	while(1) {
		if (fscanf(pfile, "%d", &n) == EOF) {
			break;
		}
		enqueue_job(n);
	}
	printf("Press any key to finish the job\n");
	char c;
	scanf("%c", &c);
	fclose(pfile);
	return 0;
}

