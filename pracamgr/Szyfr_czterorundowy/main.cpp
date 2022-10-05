#include <iostream>
#include <fstream>
#include <time.h>
using namespace std;
float hong(float x,float p);
int round=1;
long int sign_counter=0;
long int sign_counter2=0;
float k1,p1,p2;
float keyrg1;
float pg1;
float keyrg2;
float pg2;
float pg3;
float keyrg3;
float keyrg4;
float pg4;


#include "ModelOrder0C.h"

int main(int argc, char *argv[])
{



	fstream source,target,new1,new2,temp1;
	ModelI* model;
	long int size=350000;
	unsigned int *help_buffer=new unsigned int[size];
		unsigned int *pointer_buffer=help_buffer;
	for (long int k=0;k<size;k++)
	{
		pointer_buffer[k]=1000;
	}
    clock_t start,finish;
	double sekundy;

     if( argc != 5 )
	{
		cout <<"Command: AC source target key operation_number" << endl;
		cout <<"1. Encoding"<<endl;
        cout <<"2. Decoding"<<endl; 
		return 1;
	}

   source.open( argv[1], ios::in | ios::binary );
	target.open( argv[2], ios::out | ios::binary );
      	ifstream key;
   key.open(argv[3], ios::in);
   	   if( !key.is_open() )
	{
		cout << "Can not open key file";
		return 4;
	} 

   	key>>k1;
	key>>p1;
	key>>p2;
	key>>keyrg1;
	key>>pg1;
	key>>keyrg2;
    key>>pg2;
	key>>keyrg3;
	key>>pg3;
	key>>keyrg4;
	key>>pg4;
	key.close();

  

	


	int choose=atoi(argv[4]);
	if( !source.is_open() )
	{
		cout << "Can not open source file";
		return 2;
	}
	if( !target.is_open() )
	{
		cout << "Can not open target file";
		return 3;
	}	



	if (choose==1)
	{

	round=1;
 
		model = new ModelOrder0C;
	start = clock();	
	model->Process_pl_pam(&source,pointer_buffer,MODE_ENCODE);
	       source.close();
	
	

		long int reading_counter=0;	
	    unsigned int *reversed_buffer=new unsigned int[sign_counter+1];
				
        long int reversed_counter=0;
       	while(reversed_counter!=sign_counter)
		{
        unsigned int symbolll;
		symbolll=help_buffer[sign_counter-reversed_counter-1];
       	reversed_buffer[reversed_counter]=symbolll;
        reversed_counter++;
		}
		reversed_buffer[sign_counter]=1000;
		round=2;
         for (k=0;k<size;k++)
		 {
         help_buffer[k]=1000; 
		 }
		model=new ModelOrder0C;
        
		sign_counter=0;
		 model->Process_pam_pam(reversed_buffer,help_buffer,MODE_ENCODE);
       
		 unsigned int *reversed_buffer2=new unsigned int[sign_counter+1];
        reversed_counter=0;
		while(reversed_counter!=sign_counter)
		{
        unsigned int symbolll;
		symbolll=help_buffer[sign_counter-reversed_counter-1];
       	reversed_buffer2[reversed_counter]=symbolll;
        reversed_counter++;
		}
		reversed_buffer2[sign_counter]=1000;
		round=3;
	    sign_counter=0;
         for (k=0;k<size;k++)
		 {
         help_buffer[k]=1000; 
		 }
		model=new ModelOrder0C;
        
		sign_counter=0;
		 model->Process_pam_pam(reversed_buffer2,help_buffer,MODE_ENCODE);
		unsigned int *reversed_buffer3=new unsigned int[sign_counter+1];
        reversed_counter=0;
		while(reversed_counter!=sign_counter)
		{
        unsigned int symbolll;
		symbolll=help_buffer[sign_counter-reversed_counter-1];
       	reversed_buffer3[reversed_counter]=symbolll;
        reversed_counter++;
		}
		reversed_buffer3[sign_counter]=1000;
        round=4;
	
		sign_counter=0;
		
		model = new ModelOrder0C;
        model->Process_pam_pl(reversed_buffer3,&target, MODE_ENCODE );
		finish=clock();
	sekundy = (double)(finish - start) / 
    CLOCKS_PER_SEC;
    cout<<"\n Czas dzialania w sekundach="<<sekundy;

	}
	if (choose==2)
	{
		round=4;
			model = new ModelOrder0C;
    sign_counter2=0;
	sign_counter=0;
	start=clock();
	model->Process_pl_pam( &source, help_buffer, MODE_DECODE );
	
	
	
	source.close();
	long int reading_counter=0;

		sign_counter2--;
	    unsigned int *reversed_buffer=new unsigned int[sign_counter2];
        long int reversed_counter=0;
       	while(reversed_counter!=sign_counter2)
		{
        unsigned int symbolll;
		symbolll=help_buffer[sign_counter2-reversed_counter-1];
       	reversed_buffer[reversed_counter]=symbolll;
        reversed_counter++;
		}
		reversed_buffer[sign_counter2]=1000;

        round=3;
        sign_counter2=0;
	sign_counter=0;
	for (k=0;k<size;k++)
		 {
         help_buffer[k]=1000; 
		 }
        model=new ModelOrder0C;
		model->Process_pam_pam(reversed_buffer,help_buffer,MODE_DECODE);  
        round=2;

         	 reading_counter=0;
		sign_counter2--;
	    unsigned int *reversed_buffer3=new unsigned int[sign_counter2];
        reversed_counter=0;
       	while(reversed_counter!=sign_counter2)
		{
        unsigned int symbolll;
		symbolll=help_buffer[sign_counter2-reversed_counter-1];
       	reversed_buffer3[reversed_counter]=symbolll;
        reversed_counter++;
		}
		reversed_buffer3[sign_counter2]=1000;
        for (k=0;k<size;k++)
		 {
         help_buffer[k]=1000; 
		 }
		
        sign_counter=0;
		sign_counter2=0;
		model=new ModelOrder0C;
		model->Process_pam_pam(reversed_buffer3,help_buffer,MODE_DECODE);
		
		sign_counter2--;
		 unsigned int *reversed_buffer2=new unsigned int[sign_counter2];
        reversed_counter=0;
		while(reversed_counter!=sign_counter2)
		{
        unsigned int symbolll;
		symbolll=help_buffer[sign_counter2-reversed_counter-1];
       	reversed_buffer2[reversed_counter]=symbolll;
        reversed_counter++;
		}
		reversed_buffer2[sign_counter2]=1000;
        
		round=1;
		sign_counter=0;
		model = new ModelOrder0C;
model->Process_pam_pl(reversed_buffer2,&target, MODE_DECODE );
finish=clock();
	sekundy = (double)(finish - start) / 
    CLOCKS_PER_SEC;
    cout<<"\n Time of working in miliseconds="<<sekundy;


	}
	if (choose!=1 && choose!=2)
	{	
	cout<<"Wrong choose";	
	
	}
 
    target.close();
	
	return 0;
}