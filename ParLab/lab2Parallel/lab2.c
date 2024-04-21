#include <pthread.h>
#include <stdio.h>


unsigned int sleep(unsigned int seconds);

pthread_key_t fkey;
void write_to_file(char* message) {
        FILE* file = (FILE*) pthread_getspecific(fkey);
        fprintf(file, "%s\n", message);
}

void close_file(void* file) {
        fclose((FILE*) file);
}

void* alarm(void* c) {
        char filename[25];
        FILE* file;
        sprintf(filename, "thread%d.log", (int)pthread_self());
        file = fopen(filename, "w");
        pthread_setspecific(fkey, file);        

        int count = *(int*)c;
        write_to_file("Thread started working...\n");
        sleep(count);
        char message[25];
        sprintf(message, "Waited for %d seconds\n", count);
        printf("%s", message);
        write_to_file(message);
        return NULL;
}

int main() {
        pthread_key_create(&fkey, close_file);
        int num = 0;
        pthread_t t1;
        pthread_attr_t attr1;
        pthread_attr_init(&attr1);
        pthread_attr_setdetachstate(&attr1, PTHREAD_CREATE_DETACHED);
        scanf("\n %d", &num);
        while (num >= 0) {
                pthread_create(&t1, &attr1, alarm, (void*)&num);
                scanf("%d", &num);
        }
        pthread_attr_destroy(&attr1);
        
        printf("Press to finish\n");
        scanf("%d", &num);
        return 0;
}

