#ifndef __MODELORDER0C_H__
#define __MODELORDER0C_H__

#include "ModelI.h"

class ModelOrder0C : public ModelI  
{
public:
	ModelOrder0C();

protected:
	void Encode();
    void Encode_pl_pam();
	void Decode_pl_pam();
    void Decode_pam_pl();
	void Encode_pam_pl();
	void Decode_pam_pam();
	void Encode_pam_pam();
	void Decode();

	unsigned int mCumCount[ 257 ];
	unsigned int mTotal;
};

#endif 
