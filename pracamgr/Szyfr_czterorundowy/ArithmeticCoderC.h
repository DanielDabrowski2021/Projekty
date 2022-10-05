#ifndef __ARITHMETICCODERC_H__
#define __ARITHMETICCODERC_H__

#include <fstream>
using namespace std;

class ArithmeticCoderC  
{
public:
	ArithmeticCoderC();

	void SetFile( fstream *file );
    void SetBufor(unsigned int *pointer);
	void Encode( const unsigned int low_count, 
	             const unsigned int high_count, 
	             const unsigned int total );
	void Encode_pam(const unsigned int low_count, 
	             const unsigned int high_count, 
	             const unsigned int total );
	void EncodeFinish();
    void EncodeFinish_pam();
	void DecodeStart();
	void DecodeStart_pam();
	unsigned int DecodeTarget( const unsigned int total );
	void Decode( const unsigned int low_count, 
	             const unsigned int high_count );
	void Decode_pam( const unsigned int low_count,const unsigned int high_count );

protected:
	void SetBit( const unsigned char bit );
	void SetBit_pam(const unsigned char bit );
	void SetBitFlush();
    void SetBitFlush_pam();
	unsigned char GetBit();
    unsigned char GetBit_pam();
	unsigned char mBitBuffer;
	unsigned char mBitCount;

	fstream *mFile;
    unsigned int *mBuf;
	unsigned int *mBuf2;
	unsigned int mLow;
	unsigned int mHigh;
	unsigned int mStep;
	unsigned int mScale;

	unsigned int mBuffer;
};

#endif