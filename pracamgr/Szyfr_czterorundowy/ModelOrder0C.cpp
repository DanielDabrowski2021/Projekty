#include "ModelOrder0C.h"
#include <iostream>
extern long int sing_counter2;
extern float k1,p1,p2;
float hong(float x,float p)
{
if (x>=0 && x<p)
  {

return x/p;
  }
else if (x>=p && x<=0.5)
  {
  float help;
  help=(x-p)/(0.5-p);

  return help;
  }
else if (x>0.5 && x<=1)
 {

 return hong(1-x,p);
 }
else
 {

 return 0;
 }

}





ModelOrder0C::ModelOrder0C()
{

float x1,x2,x3;
int help;
float result;
float help2;
float table[257];
x1=hong(k1,p1);
x2=x1+k1;
help=x2/0.9999;
result=x2-help*0.9999;
x3=hong(result,p2);
table[0]=x3;
help2=x3;
for(int i=1;i<257;i++)
 {
 x1=hong(help2,p1);
 x2=x1+k1;
 help=x2/0.9999;//modulo operation
 result=x2-help*0.9999;
 x3=hong(result,p2);
 table[i]=x3;
 help2=x3;
 }
	
mTotal=0;
for (unsigned int j=0;j<257;j++)
{
x2=16777216*table[j];//2^24
help=x2/2097152;//2^21
result=x2-help*2097152;
	mCumCount[j]=result;
mTotal=mTotal+result;
}
}

void ModelOrder0C::Encode()
{
	while( !mSource->eof() )
	{
		unsigned char symbol;

		mSource->read( reinterpret_cast<char*>(&symbol), sizeof( symbol ) );

		if( !mSource->eof() )
		{
			unsigned int low_count = 0;
			unsigned char j;
			for( j=0; j<symbol; j++ )
				low_count += mCumCount[j];

			mAC.Encode( low_count, low_count + mCumCount[j], mTotal );

			mCumCount[ symbol ]++;
			mTotal++;
		}
	}

	mAC.Encode( mTotal-1, mTotal, mTotal );
}

void ModelOrder0C::Decode()
{
	unsigned int symbol;

	do
	{
		unsigned int value;

		value = mAC.DecodeTarget( mTotal );

		unsigned int low_count = 0;

		for( symbol=0; low_count + mCumCount[symbol] <= value; symbol++ )
			low_count += mCumCount[symbol];
      
		if( symbol < 256 )
			mTarget->write( reinterpret_cast<char*>(&symbol), sizeof( char ) );
        sing_counter2++;
		mAC.Decode( low_count, low_count + mCumCount[ symbol ] );

		mCumCount[ symbol ]++;
		mTotal++;
	}
	while( symbol != 256 );
}
void ModelOrder0C::Encode_pl_pam()
{
while( !mSource->eof() )
	{
		unsigned char symbol;

		mSource->read( reinterpret_cast<char*>(&symbol), sizeof( symbol ) );

		if( !mSource->eof() )
		{
			unsigned int low_count = 0;
			unsigned char j;
			for( j=0; j<symbol; j++ )
				low_count += mCumCount[j];

			mAC.Encode_pam( low_count, low_count + mCumCount[j], mTotal );

			mCumCount[ symbol ]++;
			mTotal++;
		}
	}

	mAC.Encode_pam( mTotal-1, mTotal, mTotal );

}
void ModelOrder0C::Decode_pl_pam()
{
unsigned int symbol;

	do
	{
		unsigned int value;

		value = mAC.DecodeTarget( mTotal );

		unsigned int low_count = 0;

		for( symbol=0; low_count + mCumCount[symbol] <= value; symbol++ )
			low_count += mCumCount[symbol];
      
		if( symbol < 256 )
			
        *mBuf=(unsigned int)symbol;
			mBuf++;
			sing_counter2++;
		mAC.Decode( low_count, low_count + mCumCount[ symbol ] );

		mCumCount[ symbol ]++;
		mTotal++;
	}
	while( symbol != 256 );

}
void ModelOrder0C::Decode_pam_pl()
{
unsigned int symbol;

	do
	{
		unsigned int value;

		value = mAC.DecodeTarget( mTotal );

		unsigned int low_count = 0;

		for( symbol=0; low_count + mCumCount[symbol] <= value; symbol++ )
			low_count += mCumCount[symbol];
      
		if( symbol < 256 )
			mTarget->write( reinterpret_cast<char*>(&symbol), sizeof( char ) );	
        sing_counter2++;
		mAC.Decode_pam( low_count, low_count + mCumCount[ symbol ] );

		mCumCount[ symbol ]++;
		mTotal++;
	}
	while( symbol != 256 );

}
void ModelOrder0C::Encode_pam_pl()
{
	while(*mBuf<1000)
	{
		unsigned char symbol;

	
        symbol=(unsigned char)*mBuf;
		if(*mBuf<1000)
		{
			unsigned int low_count = 0;
			unsigned char j;
			for( j=0; j<symbol; j++ )
				low_count += mCumCount[j];

			mAC.Encode( low_count, low_count + mCumCount[j], mTotal );

			mCumCount[ symbol ]++;
			mTotal++;
		}
		mBuf++;
	}
 
	mAC.Encode( mTotal-1, mTotal, mTotal );
}
void ModelOrder0C::Encode_pam_pam()
{
	while(*mBuf2<1000)
	{
		unsigned char symbol;

	
        symbol=(unsigned char)*mBuf2;
		if(*mBuf2<1000)
		{
			unsigned int low_count = 0;
			unsigned char j;
			for( j=0; j<symbol; j++ )
				low_count += mCumCount[j];

			mAC.Encode_pam( low_count, low_count + mCumCount[j], mTotal );

			mCumCount[ symbol ]++;
			mTotal++;
		}
		mBuf2++;
	}
 
	mAC.Encode_pam( mTotal-1, mTotal, mTotal );
}
void ModelOrder0C::Decode_pam_pam()
{
unsigned int symbol;

	do
	{
		unsigned int value;

		value = mAC.DecodeTarget( mTotal );

		unsigned int low_count = 0;

		for( symbol=0; low_count + mCumCount[symbol] <= value; symbol++ )
			low_count += mCumCount[symbol];
      
		*mBuf2=(unsigned int)symbol;
	    mBuf2++;	
        sing_counter2++;
	
		mAC.Decode_pam( low_count, low_count + mCumCount[ symbol ] );

		mCumCount[ symbol ]++;
		mTotal++;
	}
	while( symbol != 256 );

}