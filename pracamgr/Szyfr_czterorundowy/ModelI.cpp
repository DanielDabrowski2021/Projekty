#include "ModelI.h"

void ModelI::Process( fstream *source, fstream *target, ModeE mode )
{
	mSource = source;
	mTarget = target;

	if( mode == MODE_ENCODE )
	{
		mAC.SetFile( mTarget );

		Encode();

		mAC.EncodeFinish();
	}
	else // MODE_DECODE
	{
		mAC.SetFile( mSource );

		mAC.DecodeStart();

		Decode();
	}
};
void ModelI::Process_pl_pam(fstream *source,unsigned int *targetbufor, ModeE mode )
{


	
	mSource = source;
	mBuf = targetbufor;

	if( mode == MODE_ENCODE )
	{
		
        mAC.SetBufor(mBuf);
		
		Encode_pl_pam();

		mAC.EncodeFinish_pam();
	}
	else // MODE_DECODE
	{
		mAC.SetFile( mSource );

		mAC.DecodeStart();

		Decode_pl_pam();
	}
};
void ModelI::Process_pam_pl(unsigned int *sourcebufor,fstream *target, ModeE mode )
{


	
	mTarget=target;
	mBuf = sourcebufor;

	if( mode == MODE_ENCODE )
	{
		
        mAC.SetFile(mTarget);
		
		Encode_pam_pl();
        
		mAC.EncodeFinish();
	}
	else // MODE_DECODE
	{
		mAC.SetBufor(mBuf);

		mAC.DecodeStart_pam();

		
		Decode_pam_pl();
	}
};
void ModelI::Process_pam_pam(unsigned int *sourcebufor,unsigned int *targetbufor,ModeE mode)
{



	if( mode == MODE_ENCODE )
	{
		mBuf=targetbufor;
        mBuf2=sourcebufor; 
		mAC.SetBufor(mBuf);
		Encode_pam_pam();
        
		mAC.EncodeFinish_pam();
	}
	else // MODE_DECODE
	{
		
		mBuf=sourcebufor;
		mBuf2=targetbufor;
		mAC.SetBufor(mBuf);
        mAC.DecodeStart_pam();
        Decode_pam_pam();
	}


};