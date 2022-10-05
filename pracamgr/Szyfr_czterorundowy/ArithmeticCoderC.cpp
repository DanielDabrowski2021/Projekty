#include "ArithmeticCoderC.h"
#include "tools.h"
#include <iostream>
#include <fstream>
float hong(float x,float p);
float last;//last result of function hong
extern float keyrg1;
extern float pg1;
extern float keyrg2;
extern float pg2;
extern float keyrg3;
extern float pg3;
extern float keyrg4;
extern float pg4;
extern long int sign_counter;
extern int round;
float y;
float p;
const unsigned int g_FirstQuarter = 0x20000000;
const unsigned int g_ThirdQuarter = 0x60000000;
const unsigned int g_Half         = 0x40000000;

ArithmeticCoderC::ArithmeticCoderC()
{
	mBitCount = 0;
	mBitBuffer = 0;

	mLow = 0;
	mHigh = 0x7FFFFFFF; 
	mScale = 0;

	mBuffer = 0;
	mStep = 0;
}

void ArithmeticCoderC::SetFile( fstream *file )
{
	mFile = file;
	
}
void ArithmeticCoderC::SetBufor(unsigned int *pointer)
{
mBuf=pointer;

}
void ArithmeticCoderC::SetBit( const unsigned char bit )
{
	mBitBuffer = (mBitBuffer << 1) | bit;
	mBitCount++;
	
	if(mBitCount == 8) 
	{   

	
        if (round==1 && sign_counter==0)
        {
         last=keyrg1;
         p=pg1;
	
		}
        if (round==2 && sign_counter==0)
        {
         last=keyrg2;
         p=pg2;
	
		}
        if (round==3 && sign_counter==0)
        {
         last=keyrg3;
         p=pg3;
	
		}
		if (round==4 && sign_counter==0)
        {
         last=keyrg4;
         p=pg4;
	
		}
	y=last;
	int q=16;

	for (int k=0;k<q;k++)
    {
	y=hong(y,p);

    } 

	last=y;

  float tofile;
  tofile=last*1000;
	unsigned int bity=(unsigned int)tofile;

	unsigned int mask,bitresult;
mask=255;
bitresult=bity & mask;

sign_counter++;

mBitBuffer=mBitBuffer ^ bitresult;

		mFile->write(reinterpret_cast<char*>(&mBitBuffer),sizeof(mBitBuffer));
		mBitCount = 0;
	}

}

void ArithmeticCoderC::SetBitFlush()
{

	while( mBitCount != 0 )
		SetBit( 0 );
}
void ArithmeticCoderC::SetBitFlush_pam()
{
while(mBitCount !=0)
SetBit_pam(0);
}
void ArithmeticCoderC::SetBit_pam( const unsigned char bit )
{
mBitBuffer = (mBitBuffer << 1) | bit;
	mBitCount++;
	
 
	if(mBitCount == 8)
	{   


        if (round==1 && sign_counter==0)
        {
         last=keyrg1;
         p=pg1;
		 //cout<<"key rg1 ="<<keyrg1<<"key pg1 ="<<pg1<<"\n";
		}
        if (round==2 && sign_counter==0)
        {
         last=keyrg2;
         p=pg2;
		 //cout<<"key rg2 ="<<keyrg2<<"key pg2 ="<<pg2<<"\n";
		}
          if (round==3 && sign_counter==0)
        {
         last=keyrg3;
         p=pg3;
		// cout<<"key rg3 ="<<keyrg3<<"key pg3 ="<<pg3<<"\n";
		}
        	if (round==4 && sign_counter==0)
        {
         last=keyrg4;
         p=pg4;
		 //cout<<"key rg4 ="<<keyrg4<<"key pg4 ="<<pg4<<"\n";
		}
	y=last;
	int q=16;

	for (int k=0;k<q;k++)
    {
	y=hong(y,p);

    } 

	last=y;

  float tofile;
  tofile=last*1000;
	unsigned int bity=(unsigned int)tofile;

	unsigned int mask,bitresult;
mask=255;
bitresult=bity & mask;

sign_counter++;

mBitBuffer=mBitBuffer ^ bitresult;

		*mBuf=mBitBuffer;
		mBuf++;
		mBitCount = 0;
	}

}
unsigned char ArithmeticCoderC::GetBit_pam()
{
if(mBitCount == 0) 
	{
		
		if(*mBuf<1000) 
		
		{
	

		if (round==1 && sign_counter==0)
        {
         last=keyrg1;
         p=pg1;
		 //cout<<"key rg1 ="<<keyrg1<<"key pg1 ="<<pg1<<"\n";
		}
        if (round==2 && sign_counter==0)
        {
         last=keyrg2;
         p=pg2;
		// cout<<"key rg2 ="<<keyrg2<<"key pg2 ="<<pg2<<"\n";
		}
          if (round==3 && sign_counter==0)
        {
         last=keyrg3;
         p=pg3;
		// cout<<"key rg3 ="<<keyrg3<<"key pg3 ="<<pg3<<"\n";
		}
         if (round==4 && sign_counter==0)
        {
         last=keyrg4;
         p=pg4;
		// cout<<"key rg4 ="<<keyrg4<<"key pg4 ="<<pg4<<"\n";
		}
				y=last;

	        int q=16;
	        for (int k=0;k<q;k++)
			{
	        y=hong(y,p);

			} 

	        last=y;

           float tofile;
           tofile=last*1000;
	       unsigned int bity=(unsigned int)tofile;
   
	       unsigned int mask,bitresult;
           mask=255;
           bitresult=bity & mask;
			 
		    mBitBuffer=*mBuf;
		
			mBuf++;
	
			mBitBuffer=mBitBuffer ^ bitresult;
			sign_counter++;
	
        }
		else
        
		mBitBuffer = 0; 

		mBitCount = 8;
	}


	unsigned char bit = mBitBuffer >> 7;
	mBitBuffer <<= 1;
	mBitCount--;

	return bit;
	
}
unsigned char ArithmeticCoderC::GetBit()
{
	if(mBitCount == 0) 
	{
	
		if( !( mFile->eof() ) ) 
		{
			

		if (round==1)
      //  cout<<"\n Jestem w rundzie 1 w pliku cos jest sign_counter="<<sign_counter;
		if (round==1 && sign_counter==0)
        {
         last=keyrg1;
         p=pg1;
		 //cout<<"key rg1 ="<<keyrg1<<"key pg1 ="<<pg1<<"\n";
		}
        if (round==2 && sign_counter==0)
        {
         last=keyrg2;
         p=pg2;
		 //cout<<"key rg2 ="<<keyrg2<<"key pg2 ="<<pg2<<"\n";
		}
        if (round==3 && sign_counter==0)
        {
         last=keyrg3;
         p=pg3;
		// cout<<"key rg3 ="<<keyrg3<<"key pg3 ="<<pg3<<"\n";
		}
			if (round==4 && sign_counter==0)
        {
         last=keyrg4;
         p=pg4;
		// cout<<"key rg4 ="<<keyrg4<<"key pg4 ="<<pg4<<"\n";
		}	
		y=last;

	        int q=16;
	        for (int k=0;k<q;k++)
			{
	        y=hong(y,p);

			} 

	        last=y;

           float tofile;
           tofile=last*1000;
	       unsigned int bity=(unsigned int)tofile;
    
	       unsigned int mask,bitresult;
           mask=255;
           bitresult=bity & mask;
			 
		    mFile->read(reinterpret_cast<char*>(&mBitBuffer),sizeof(mBitBuffer));
	        
		
			 
			mBitBuffer=mBitBuffer ^ bitresult;
			sign_counter++;
	
        }
		else
       
		mBitBuffer = 0; 

		mBitCount = 8;
	}


	unsigned char bit = mBitBuffer >> 7;
	mBitBuffer <<= 1;
	mBitCount--;

	return bit;
}

void ArithmeticCoderC::Encode( const unsigned int low_count, 
															 const unsigned int high_count, 
															 const unsigned int total )
// total < 2^29
{

	mStep = ( mHigh - mLow + 1 ) / total;


	mHigh = mLow + mStep * high_count - 1; 
	

	mLow = mLow + mStep * low_count;

	// e1/e2 
	while( ( mHigh < g_Half ) || ( mLow >= g_Half ) )
		{
			if( mHigh < g_Half )
			{
				SetBit( 0 );
				mLow = mLow * 2;
				mHigh = mHigh * 2 + 1;

				// e3
				for(; mScale > 0; mScale-- )
					SetBit( 1 );
			}
			else if( mLow >= g_Half )
			{
				SetBit( 1 );
				mLow = 2 * ( mLow - g_Half );
				mHigh = 2 * ( mHigh - g_Half ) + 1;

				// e3
				for(; mScale > 0; mScale-- )
					SetBit( 0 );
			}
		}

	// e3
	while( ( g_FirstQuarter <= mLow ) && ( mHigh < g_ThirdQuarter ) )
	{
		mScale++;
		mLow = 2 * ( mLow - g_FirstQuarter );
		mHigh = 2 * ( mHigh - g_FirstQuarter ) + 1;
	}
}
void ArithmeticCoderC::Encode_pam( const unsigned int low_count, 
															 const unsigned int high_count, 
															 const unsigned int total )
{

	mStep = ( mHigh - mLow + 1 ) / total; 


	mHigh = mLow + mStep * high_count - 1; 
	
	
	mLow = mLow + mStep * low_count;

	
	while( ( mHigh < g_Half ) || ( mLow >= g_Half ) )
		{
			if( mHigh < g_Half )
			{
				SetBit_pam( 0 );
				mLow = mLow * 2;
				mHigh = mHigh * 2 + 1;

				
				for(; mScale > 0; mScale-- )
					SetBit_pam( 1 );
			}
			else if( mLow >= g_Half )
			{
				SetBit_pam( 1 );
				mLow = 2 * ( mLow - g_Half );
				mHigh = 2 * ( mHigh - g_Half ) + 1;

			
				for(; mScale > 0; mScale-- )
					SetBit_pam( 0 );
			}
		}


	while( ( g_FirstQuarter <= mLow ) && ( mHigh < g_ThirdQuarter ) )
	{
		mScale++;
		mLow = 2 * ( mLow - g_FirstQuarter );
		mHigh = 2 * ( mHigh - g_FirstQuarter ) + 1;
	}
}
void ArithmeticCoderC::EncodeFinish()
{

	
	if( mLow < g_FirstQuarter ) // mLow < FirstQuarter < Half <= mHigh
	{
		SetBit( 0 );

		for( int i=0; i<mScale+1; i++ ) // 1 + e3
			SetBit(1);
	}
	else // mLow < Half < ThirdQuarter <= mHigh
	{
		SetBit( 1 ); 
	}

	
	SetBitFlush();
}
void ArithmeticCoderC::EncodeFinish_pam()
{

	
	if( mLow < g_FirstQuarter ) // mLow < FirstQuarter < Half <= mHigh
	{
		SetBit_pam( 0 );

		for( int i=0; i<mScale+1; i++ )
			SetBit_pam(1);
	}
	else // mLow < Half < ThirdQuarter <= mHigh
	{
		SetBit_pam( 1 ); 
	}


	SetBitFlush_pam();


}
void ArithmeticCoderC::DecodeStart()
{

	for( int i=0; i<31; i++ ) 
		mBuffer = ( mBuffer << 1 ) | GetBit();
	
}
void ArithmeticCoderC::DecodeStart_pam()
{
	for( int i=0; i<31; i++ ) 
		mBuffer = ( mBuffer << 1 ) | GetBit_pam();
  
}
unsigned int ArithmeticCoderC::DecodeTarget( const unsigned int total )
// total < 2^29
{
	mStep = ( mHigh - mLow + 1 ) / total; 

	return ( mBuffer - mLow ) / mStep;	
}

void ArithmeticCoderC::Decode( const unsigned int low_count, 
															 const unsigned int high_count )
{	
	mHigh = mLow + mStep * high_count - 1; 

	mLow = mLow + mStep * low_count;

	// e1/e2
	while( ( mHigh < g_Half ) || ( mLow >= g_Half ) )
		{
			if( mHigh < g_Half )
			{
				mLow = mLow * 2;
				mHigh = mHigh * 2 + 1;
				mBuffer = 2 * mBuffer + GetBit();
			}
			else if( mLow >= g_Half )
			{
				mLow = 2 * ( mLow - g_Half );
				mHigh = 2 * ( mHigh - g_Half ) + 1;
				mBuffer = 2 * ( mBuffer - g_Half ) + GetBit();
			}
			mScale = 0;
		}

	// e3
	while( ( g_FirstQuarter <= mLow ) && ( mHigh < g_ThirdQuarter ) )
	{
		mScale++;
		mLow = 2 * ( mLow - g_FirstQuarter );
		mHigh = 2 * ( mHigh - g_FirstQuarter ) + 1;
		mBuffer = 2 * ( mBuffer - g_FirstQuarter ) + GetBit();
	}
}
void ArithmeticCoderC::Decode_pam( const unsigned int low_count, 
															 const unsigned int high_count )
{	
	
	mHigh = mLow + mStep * high_count - 1; 


	mLow = mLow + mStep * low_count;


	while( ( mHigh < g_Half ) || ( mLow >= g_Half ) )
		{
			if( mHigh < g_Half )
			{
				mLow = mLow * 2;
				mHigh = mHigh * 2 + 1;
				mBuffer = 2 * mBuffer + GetBit_pam();
			}
			else if( mLow >= g_Half )
			{
				mLow = 2 * ( mLow - g_Half );
				mHigh = 2 * ( mHigh - g_Half ) + 1;
				mBuffer = 2 * ( mBuffer - g_Half ) + GetBit_pam();
			}
			mScale = 0;
		}


	while( ( g_FirstQuarter <= mLow ) && ( mHigh < g_ThirdQuarter ) )
	{
		mScale++;
		mLow = 2 * ( mLow - g_FirstQuarter );
		mHigh = 2 * ( mHigh - g_FirstQuarter ) + 1;
		mBuffer = 2 * ( mBuffer - g_FirstQuarter ) + GetBit_pam();
	}
}