#ifndef __MODELI_H__
#define __MODELI_H__

#include "ArithmeticCoderC.h"

enum ModeE
{
	MODE_ENCODE = 0,
	MODE_DECODE
};

class ModelI  
{
public:
	void Process( fstream *source, fstream *target, ModeE mode );
    void Process_pl_pam(fstream *source,unsigned int *targetbufor,ModeE mode);
    void Process_pam_pl(unsigned int *sourcebufor,fstream *target,ModeE mode);
    void Process_pam_pam(unsigned int *sourcebufor,unsigned int *targetbufor,ModeE mode);
protected:
	virtual void Encode() = 0;
	virtual void Decode() = 0;
    virtual void Encode_pl_pam()=0;
    virtual void Decode_pl_pam()=0;
	virtual void Decode_pam_pl()=0;
    virtual void Encode_pam_pl()=0;
    virtual void Decode_pam_pam()=0;
	virtual void Encode_pam_pam()=0;
	ArithmeticCoderC mAC;
	fstream *mSource;
	fstream *mTarget;
	unsigned int *mBuf;
	unsigned int *mBuf2;
};

#endif
