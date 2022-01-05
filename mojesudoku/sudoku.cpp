// sudoku.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream.h>
#include <fstream.h>
#include <time.h>
int main(int argc, char *argv[])
{
clock_t start,finish;
	double seconds;
int initial_table[10][10];
fstream source,target,log;


source.open( argv[1], ios::in | ios::binary );

int i,j;
for (i=1;i<10;i++)
{
 for (j=1;j<10;j++)
  {
  int temp;
  source>>temp;
  if (temp==0)
   {
   initial_table[i][j]=511;
   
   }
  if (temp==1)
   {
   initial_table[i][j]=1;
   }
   if (temp==2)
   {
   initial_table[i][j]=2;
   }
   if (temp==3)
   {
   initial_table[i][j]=4;
   } 
   if (temp==4)
   {
   initial_table[i][j]=8;
   }
   if (temp==5)
   {
   initial_table[i][j]=16;
   }
   if (temp==6)
   {
   initial_table[i][j]=32;
   }
   if (temp==7)
   {
   initial_table[i][j]=64;
   }
   if (temp==8)
   {
   initial_table[i][j]=128;
   }
   if (temp==9)
   {
   initial_table[i][j]=256;
   }
  }

}
source.close();
start = clock();

int end=1;
int switchonsecond=1;
int counter22=0;

while(end)
{
   counter22++;
end=0;    
   int indexw;
   int indexk;
   int amod;
   int bmod;
   int cmod;
   int dmod;
switchonsecond=1;
  for (i=1;i<10;i++)
  {
  for (j=1;j<10;j++)
   {
    int help=initial_table[i][j];
  
    if (help!=256 && help!=128 && help!=64 && help!=32 && help !=16 && help!=8 && help!=4 && help !=2 && help!=1)
    {
  
       end=1;
      //checking columns
 	for (int a=1;a<10;a++)
        {
      
	   if (a!=i)
  		{
		help=initial_table[a][j];
        
       if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			{
			 int temp1=help;
          
    
        
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
		
          if (temp3>0)
				{	
          
				initial_table[i][j]=initial_table[i][j]^help;		
			
            switchonsecond=0;
       
  				}	//if		
			}//if

		}//if a

	}//for a
      //checking rows
      for (int b=1;b<10;b++)
        {
      
	   if (b!=j)
  		{
		help=initial_table[i][b];
      
         if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			{
                   
			 int temp1=help;
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
			  if (temp3>0)
				{	
			
				initial_table[i][j]=initial_table[i][j]^help;	
              switchonsecond=0;
        
				}	//if		
			}//if

		}//if

	}//for b
	//checking quads 
	if (i<4 && j<4) //first quad
        {
	 amod=i % 3;
 
	 bmod=j % 3;
  
		for (int c=1;c<4;c++)
		{
		  for (int d=1;d<4;d++)
		   {
          cmod=c % 3;
       
	      dmod=d % 3;
		     if (amod!=cmod && bmod!=dmod)//not checking in the same line
			{
				help=initial_table[c][d];
			    if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			   {
			 int temp1=help;
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
			  if (temp3>0)
				{	
				initial_table[i][j]=initial_table[i][j]^help;
				switchonsecond=0;
            
				}	//if		
			   }//if
			}//if
		   }	//for	   
		
		}//for
 		
	}//if	
        if (i<4 && j>3 && j<7) //2 quad
        {
        //   //log<<"cos";
  	amod=i % 3;
	bmod=j % 3;
		for (int c=1;c<4;c++)
		{
		  for (int d=4;d<7;d++)
		   {
             cmod=c % 3;
       
	      dmod=d % 3;
		     if (amod!=cmod && bmod!=dmod)//not checking in the same line
			{
           
        
               help=initial_table[c][d];
          
			    if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			   {
			 int temp1=help;
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
			  if (temp3>0)
				{	
				initial_table[i][j]=initial_table[i][j]^help;
				switchonsecond=0;	
            
				}			
			   }
			}
		   }		   
		
		}
 		
	}
	if (i<4 && j>6) //3 quad
        {
	amod=i % 3;
	bmod=j % 3;
		for (int c=1;c<4;c++)
		{
		  for (int d=7;d<10;d++)
		   {
             cmod=c % 3;
      
	      dmod=d % 3;
		     if (amod!=cmod && bmod!=dmod)//not checking in the same line
			{
				help=initial_table[c][d];
			    if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			   {
			 int temp1=help;
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
			  if (temp3>0)
				{	
				initial_table[i][j]=initial_table[i][j]^help;
				switchonsecond=0;
          
				}			
			   }
			}
		   }		   
		
		}
 		
	}	
      //second line of quads 
        if (i>3 && i<7 && j<4) //4 quad
        {
	amod=i % 3;
	bmod=j % 3;
		for (int c=4;c<7;c++)
		{
		  for (int d=1;d<4;d++)
		   {
             cmod=c % 3;
      
	      dmod=d % 3;
		     if (amod!=cmod && bmod!=dmod)//not checking in the same line
			{
				help=initial_table[c][d];
			    if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			   {
			 int temp1=help;
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
			  if (temp3>0)
				{	
				initial_table[i][j]=initial_table[i][j]^help;
				switchonsecond=0;
            
				}			
			   }
			}
		   }		   
		
		}
 		
	}	
        if (i>3 && i<7 && j>3 && j<7) //5 quad
        {
	amod=i % 3;
	bmod=j % 3;
		for (int c=4;c<7;c++)
		{
		  for (int d=4;d<7;d++)
		   {
             cmod=c % 3;
     
	      dmod=d % 3;
		     if (amod!=cmod && bmod!=dmod)//not checking in the same line
			{
				help=initial_table[c][d];
			
            if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			   {
			 int temp1=help;
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
			  if (temp3>0)
				{	
				initial_table[i][j]=initial_table[i][j]^help;
				switchonsecond=0;
           
				}			
			   }
			}
		   }		   
		
		}
 		
	}
	if (i>3 && i<7 && j>6) //6 quad
        {
	amod=i % 3;
	bmod=j % 3;
		for (int c=4;c<7;c++)
		{
		  for (int d=7;d<10;d++)
		   {
             cmod=c % 3;
      
	      dmod=d % 3;
		     if (amod!=cmod && bmod!=dmod)//not checking in the same line
			{
				help=initial_table[c][d];
			    if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			   {
			 int temp1=help;
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
			  if (temp3>0)
				{	
				initial_table[i][j]=initial_table[i][j]^help;
				switchonsecond=0;
           
				}			
			   }
			}
		   }		   
		
		}
 		
	}	

	//second	
       //third line of quads 
        if (i>7 && i<7 && j<4) //7 quad
        {
	amod=i % 3;
	bmod=j % 3;
		for (int c=7;c<10;c++)
		{
		  for (int d=1;d<4;d++)
		   {
             cmod=c % 3;
     
	      dmod=d % 3;
		     if (amod!=cmod && bmod!=dmod)//not checking in the same line
			{
				help=initial_table[c][d];
			    if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			   {
			 int temp1=help;
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
			  if (temp3>0)
				{	
				initial_table[i][j]=initial_table[i][j]^help;
				switchonsecond=0;
          
				}			
			   }
			}
		   }		   
		
		}
 		
	}	
        if (i>7 && j>3 && j<7) //8 quad
        {
	amod=i % 3;
	bmod=j % 3;
		for (int c=7;c<10;c++)
		{
		  for (int d=4;d<7;d++)
		   {
             cmod=c % 3;
    
	      dmod=d % 3;
		     if (amod!=cmod && bmod!=dmod)//not checking in the same line
			{
				help=initial_table[c][d];
			    if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			   {
			 int temp1=help;
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
			  if (temp3>0)
				{	
				initial_table[i][j]=initial_table[i][j]^help;
				switchonsecond=0;
           
				}			
			   }
			}
		   }		   
		
		}
 		
	}
	if (i>7 && j>6) //9 quad
        {
	amod=i % 3;
	bmod=j % 3;
		for (int c=7;c<10;c++)
		{
		  for (int d=7;d<10;d++)
		   {
             cmod=c % 3;
     
	      dmod=d % 3;
		     if (amod!=cmod && bmod!=dmod)//not checking in the same line
			{
				help=initial_table[c][d];
			    if (help==256 || help==128 || help==64 || help==32 || help ==16 || help==8 || help==4 || help ==2 || help==1)
			   {
			 int temp1=help;
			 int temp2=initial_table[i][j];
			 int temp3=temp1 & temp2;
			  if (temp3>0)
				{	
				initial_table[i][j]=initial_table[i][j]^help;
				switchonsecond=0;
          
				}			
			   }
			}
		   }		   
		
		}
 		
	}	
   
    } //end of if

    else
    {
 

    } //if else
   }//for
  }//for
//second way of searching 
switchonsecond=1;
while(switchonsecond)
{
 //  log <<"Here";
  //searching in rows
   for(int e=1;e<10;e++)//rows
   {
	for(int g=1;g<10;g++)//numbers
	{
	int counter=0;
	int index=0;
	   for(int f=1;f<10;f++)//field
	    {
		int temp1=initial_table[e][f];
		int temp2;
   
		if (g==1)
   		{
   		temp2=1;
   		}
   		if (g==2)
   		{
   		temp2=2;
   		}
   		if (g==3)
   		{
   		temp2=4;
   		} 
   		if (g==4)
   		{
   		temp2=8;
   		}
   		if (g==5)
   		{
   		temp2=16;
   		}
   		if (g==6)
   		{
   		temp2=32;
   		}
   		if (g==7)
   		{
   		temp2=64;
   		}
   		if (g==8)
   		{
   		temp2=128;
   		}
   		if (g==9)
   		{
   		temp2=256;
   		}
		int result;
		result=temp1&temp2;
		if (result>0)
		{
		counter++;
		index=f;
		}
	    }//fields of row 
      int temp4=initial_table[e][index];
      if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{//counter
      
			if (g==1)
   		{
   		initial_table[e][index]=1;
		switchonsecond=0;
     
   		}
   		if (g==2)
   		{
   		initial_table[e][index]=2;
		switchonsecond=0;
         
   		}
   		if (g==3)
   		{
   		initial_table[e][index]=4;
		switchonsecond=0;
          
   		} 
   		if (g==4)
   		{
   		initial_table[e][index]=8;
		switchonsecond=0;
          
   		}
   		if (g==5)
   		{
   		initial_table[e][index]=16;
		switchonsecond=0;
          
   		}
   		if (g==6)
   		{
   		initial_table[e][index]=32;
		switchonsecond=0;
          
   		}
   		if (g==7)
   		{
   		initial_table[e][index]=64;
		switchonsecond=0;
          
   		}
   		if (g==8)
   		{
   		initial_table[e][index]=128;
		switchonsecond=0;
          
   		}
   		if (g==9)
   		{
   		initial_table[e][index]=256;
		switchonsecond=0;
           
   		}	
	
	   }//counter	
	}//numbers
   }//rows
//columns
//
   for(e=1;e<10;e++)//columns
   {
	for(int g=1;g<10;g++)//numbers
	{
	int counter=0;
	int index=0;
	   for(int f=1;f<10;f++)//fields
	    {
		int temp1=initial_table[f][e];
		int temp2;
		if (g==1)
   		{
   		temp2=1;
   		}
   		if (g==2)
   		{
   		temp2=2;
   		}
   		if (g==3)
   		{
   		temp2=4;
   		} 
   		if (g==4)
   		{
   		temp2=8;
   		}
   		if (g==5)
   		{
   		temp2=16;
   		}
   		if (g==6)
   		{
   		temp2=32;
   		}
   		if (g==7)
   		{
   		temp2=64;
   		}
   		if (g==8)
   		{
   		temp2=128;
   		}
   		if (g==9)
   		{
   		temp2=256;
   		}
		int result;
		result=temp1&temp2;
		if (result>0)
		{
		counter++;
		index=f;
		}
	    }//fields fo rows
     int temp4=initial_table[index][e];
	if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{//counter
     
			if (g==1)
   		{
   		initial_table[index][e]=1;
		switchonsecond=0;
   		}
   		if (g==2)
   		{
   		initial_table[index][e]=2;
		switchonsecond=0;
   		}
   		if (g==3)
   		{
   		initial_table[index][e]=4;
		switchonsecond=0;
   		} 
   		if (g==4)
   		{
   		initial_table[index][e]=8;
		switchonsecond=0;
   		}
   		if (g==5)
   		{
   		initial_table[index][e]=16;
		switchonsecond=0;
   		}
   		if (g==6)
   		{
   		initial_table[index][e]=32;
		switchonsecond=0;
   		}
   		if (g==7)
   		{
   		initial_table[index][e]=64;
		switchonsecond=0;
   		}
   		if (g==8)
   		{
   		initial_table[index][e]=128;
		switchonsecond=0;
   		}
   		if (g==9)
   		{
   		initial_table[index][e]=256;
		switchonsecond=0;
   		}	
	
	   }//	columns
	}//numbers
   }//fields
    //checkinf for first quad
      
          //checking for numbers
	   for (int g=1;g<10;g++)
            {
		int counter=0;
	   indexw=0;		
		indexk=0;	
		for (int c=1;c<4;c++)//rows quad  1
		{
		  for (int d=1;d<4;d++)//columns
			{
			int temp1=initial_table[c][d];
			switchonsecond=0;
			int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
			int result=0;
			result=temp1&temp2;
			if (result>0)
				{
				counter++;
				indexw=c;
				indexk=d;
				}
			}//end of for
		}
     int temp4=initial_table[indexw][indexk];
	    if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{
          
		int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
		initial_table[indexw][indexk]=temp2;
		switchonsecond=0;
		}	
            }
	//oquad 2
	//checking for numbers
	   for ( g=1;g<10;g++)
            {
		int counter=0;
		indexw=0;		
		indexk=0;	
		for (int c=1;c<4;c++)//rows quad 2
		{
		  for (int d=4;d<7;d++)//columns
			{
			int temp1=initial_table[c][d];
			switchonsecond=0;
			int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
			int result=0;
			result=temp1&temp2;
			if (result>0)
				{
				counter++;
				indexw=c;
				indexk=d;
				}
			}//end of for
		}
       int temp4=initial_table[indexw][indexk];
	    if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{
         
		int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
		initial_table[indexw][indexk]=temp2;
		switchonsecond=0;
		}	
            }
		//quad 3
           //checking for numbers
	   for ( g=1;g<10;g++)
            {
		int counter=0;
		indexw=0;		
		indexk=0;	
		for (int c=1;c<4;c++)//rows quad 3
		{
		  for (int d=7;d<10;d++)//columns
			{
			int temp1=initial_table[c][d];
			switchonsecond=0;
			int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
			int result=0;
			result=temp1&temp2;
			if (result>0)
				{
				counter++;
				indexw=c;
				indexk=d;
				}
			}//end of for
		}
        int temp4=initial_table[indexw][indexk];
	    if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{
          
		int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
		initial_table[indexw][indexk]=temp2;
		switchonsecond=0;
		}	
            }
		//checking for numbers
	   for (g=1;g<10;g++)
            {
		int counter=0;
		indexw=0;		
		indexk=0;	
		for (int c=4;c<7;c++)//rows quad 4
		{
		  for (int d=1;d<4;d++)//columns
			{
			int temp1=initial_table[c][d];
			switchonsecond=0;
			int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
			int result=0;
			result=temp1&temp2;
			if (result>0)
				{
				counter++;
				indexw=c;
				indexk=d;
				}
			}//end of for
		}
       int temp4=initial_table[indexw][indexk];
	    if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{
        
		int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
		initial_table[indexw][indexk]=temp2;
		switchonsecond=0;
		}	
            }
//checking of numbers
	   for ( g=1;g<10;g++)
            {
		int counter=0;
		indexw=0;		
		indexk=0;	
		for (int c=4;c<7;c++)//rows quad 5
		{
		  for (int d=4;d<7;d++)//columns
			{
			int temp1=initial_table[c][d];
			switchonsecond=0;
			int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
			int result=0;
			result=temp1&temp2;
			if (result>0)
				{
				counter++;
				indexw=c;
				indexk=d;
				}
			}//end of for
		}
       int temp4=initial_table[indexw][indexk];
	    if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{
          
		int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
		initial_table[indexw][indexk]=temp2;
		switchonsecond=0;
		}	
            }
//checking for numbers
	   for ( g=1;g<10;g++)
            {
		int counter=0;
		indexw=0;		
		indexk=0;	
		for (int c=4;c<7;c++)//rows quad 6
		{
		  for (int d=7;d<10;d++)//columns
			{
			int temp1=initial_table[c][d];
			switchonsecond=0;
			int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
			int result=0;
			result=temp1&temp2;
			if (result>0)
				{
				counter++;
				indexw=c;
				indexk=d;
				}
			}//end of for 
		}
       int temp4=initial_table[indexw][indexk];
	    if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{
          
		int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
		initial_table[indexw][indexk]=temp2;
		switchonsecond=0;
		}	
            }
	   for ( g=1;g<10;g++)
            {
		int counter=0;
		indexw=0;		
		indexk=0;	
		for (int c=7;c<10;c++)//rows quad 7
		{
		  for (int d=1;d<4;d++)//columns
			{
			int temp1=initial_table[c][d];
			switchonsecond=0;
			int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
			int result=0;
			result=temp1&temp2;
			if (result>0)
				{
				counter++;
				indexw=c;
				indexk=d;
				}
			}//end of for
		}
       int temp4=initial_table[indexw][indexk];
	    if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{
         
		int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
		initial_table[indexw][indexk]=temp2;
		switchonsecond=0;
		}	
            }
	   for ( g=1;g<10;g++)
            {
		int counter=0;
		indexw=0;		
		indexk=0;	
		for (int c=7;c<10;c++)//rows quad 8
		{
		  for (int d=4;d<7;d++)//columns
			{
			int temp1=initial_table[c][d];
			switchonsecond=0;
			int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
			int result=0;
			result=temp1&temp2;
			if (result>0)
				{
				counter++;
				indexw=c;
				indexk=d;
				}
			}//end of for
		}
       int temp4=initial_table[indexw][indexk];
	    if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{
          
		int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
		initial_table[indexw][indexk]=temp2;
		switchonsecond=0;
		}	
            }
	   for ( g=1;g<10;g++)
            {
		int counter=0;
		indexw=0;		
		indexk=0;	
		for (int c=7;c<10;c++)//rows quad 9
		{
		  for (int d=7;d<10;d++)//columns
			{
			int temp1=initial_table[c][d];
			switchonsecond=0;
			int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
			int result=0;
			result=temp1&temp2;
			if (result>0)
				{
				counter++;
				indexw=c;
				indexk=d;
				}
			}//end of for
		}
       int temp4=initial_table[indexw][indexk];
	    if (counter==1 && temp4!=256 && temp4!=128 && temp4!=64 && temp4!=32 && temp4 !=16 && temp4!=8 && temp4!=4 && temp4!=2 && temp4!=1)
		{
          
		int temp2=0;
			if (g==1)
   			{
   			temp2=1;
   			}
   			if (g==2)
   			{
   			temp2=2;
   			}
   			if (g==3)
   			{
   			temp2=4;
   			} 
   			if (g==4)
   			{
   			temp2=8;
   			}
   			if (g==5)
   			{
   			temp2=16;
   			}
   			if (g==6)
   			{
   			temp2=32;
   			}
   			if (g==7)
   			{
   			temp2=64;
   			}
   			if (g==8)
   			{
   			temp2=128;
   			}
   			if (g==9)
   			{
   			temp2=256;
   			}
		initial_table[indexw][indexk]=temp2;
		switchonsecond=0;
		}	
            }
 }//second way
//end=0;
}//while main

//writing to file,writing time
target.open( argv[2], ios::out | ios::binary );
target<<"Single solution version \r\n";
for ( i=1;i<10;i++)
{
 for (j=1;j<10;j++)
  {
 
    int help=initial_table[i][j];
   if (help!=256 && help!=128 && help!=64 && help!=32 && help !=16 && help!=8 && help!=4 && help !=2 && help!=1)
   {
   target<<help;
   target<<"+ ";
   }   
      if (initial_table[i][j]==1)
   {
   target<<1;
   target<<" ";
   }
   if (initial_table[i][j]==2)
   {
   target<<2;
   target<<" ";
   }
   if (initial_table[i][j]==4)
   {
   target<<3;
   target<<" ";
   }
   if (initial_table[i][j]==8)
   {
   target<<4;
   target<<" ";
   }
   if (initial_table[i][j]==16)
   {
   target<<5;
   target<<" ";
   }
   if (initial_table[i][j]==32)
   {
   target<<6;
   target<<" ";
   }
   if (initial_table[i][j]==64)
   {
   target<<7;
   target<<" ";
   }
   if (initial_table[i][j]==128)
   {
   target<<8;
   target<<" ";
   }
   if (initial_table[i][j]==256)
   {
   target<<9;
   target<<" ";
   }
 
  }
 target<<"\r\n";
}
finish=clock();
	seconds = (double)(finish - start) / 
    CLOCKS_PER_SEC;

target<<"Time of working in milisecons: "<<seconds*1000;
target<<"\r\n Time of working in clocks:"<<((double)(finish-start));
target.close();
//log.close();
return 0;
}


