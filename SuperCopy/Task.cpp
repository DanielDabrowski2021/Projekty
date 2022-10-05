// Task.cpp: implementation of the Task class.
#include "stdafx.h"
#include "SuperCopy.h"
#include "Task.h"
#include "SuperCopyDlg.h"
#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif
int iRC2;
int iRC3;

Task::Task()
{

}

Task::~Task()
{

}

UINT Task::fnCreateFileTask(LPVOID pParam)
{
Task* pTask= (Task*)pParam;
int iResult=0;

while(pTask->iState==0) //Task in state:Paused
{
Sleep(300);
}
if (pTask->iState==3) //Task in state:Aborted
{
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);//Change task state in task list

return 0;
}
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
iResult = pTask->fnCopyFile();//start copying file
 if(iResult)
		{
		pTask->iState=4;
		}
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
while(pTask->iState==4)//Task in state:Failed
{
 if (pTask->iState==1)////Task in state:Running,copy again
  {
	 pTask->sError="";
     pTask->fProcent=0;
	  ::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
   iResult=pTask->fnCopyFile(); 
    if(iResult)
		{
		pTask->iState=4;
		}//start copying file
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
  }
 if (pTask->iState==0)
  {
  pTask->iState=4; 
  ::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
  }

}
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);

if (pTask->iState==1)//Task in state:Running
{

pTask->iState=2;//Task in state:Finished
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
}  


return 0;
}

UINT Task::fnCreateDirectoryTask(LPVOID pParam)
{
Task* pTask = (Task*)pParam;
Task help;
    help.sSource=pTask->sSource;
    help.lSize=0;
	int a=help.fnGetDirectorySize();//get direcory size
	pTask->lSize=help.lSize;	
if (pTask->lSize==0)//only subdirectories in directory
{
pTask->lSize=1;
}
int iResult=0;
while(pTask->iState==0)//Task state:paused
{
Sleep(300);
}
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);//Change task state in task list

if (pTask->iState==3) //Task state:aborted
{
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
return 0;
}
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);

iResult=pTask->fnCopyDirectory();//start copying directory
if(iResult)
{
pTask->iState=4;
}
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);

while(pTask->iState==4)//Task state:failed
{
	Sleep(300);
  if (pTask->iState==1)//Task state:running
  {
	   pTask->sError="";
	  pTask->fProcent=0;
	  ::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
	  iResult=pTask->fnCopyDirectory();//start copying directory again
	  if(iResult)
		{
		pTask->iState=4;
		}
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
  }
  if (pTask->iState==0)
  {
  pTask->iState=4; 
  ::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
  }

}

if (pTask->iState==3)//Task state:aborted
{
	::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);
	if(pTask->sDestination.Compare(pTask->sSource)!=0)//Source is not equal destination
			{
		pTask->fnDeleteDirectory(pTask->sDestination);//delete created directory
			}
	
return 0;

}
if (pTask->iState==1)//Task state:running
{

pTask->iState=2;//Task state:finished
::PostMessage(pTask->hWindow, WM_TASKCHANGE, pTask->iState,pTask->iIndex);

}

return 0;
}

int Task::fnCopyDirectory()
{
CString     strSource;               // Source file
CString     strDestination;          // Destination file
CString     strPattern;              // Pattern
HANDLE          hFile;                   // Handle to file
WIN32_FIND_DATA FileInformation; 
strSource=sSource;

  strPattern = sSource + "\\*.*";
  strDestination=sDestination;

  // Create destination directory
  if(::CreateDirectory(strDestination, 0) == FALSE)
  {
	  sError="Couldn't create destination directory: \n"+strDestination;
      iState=4; //Task state:Failed
  return ::GetLastError();
  }
  
  hFile = ::FindFirstFile(strPattern, &FileInformation);//Find files and directories in source directory
  if(hFile != INVALID_HANDLE_VALUE)
  {
    do
    {
      if(FileInformation.cFileName[0] != '.')
      {
        strSource="";
      strDestination="";
         
        strSource      = sSource + "\\" + FileInformation.cFileName;
        strDestination = sDestination + "\\" + FileInformation.cFileName;

        if(FileInformation.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
        {
          // Copy subdirectory
			Task object;
			object.sDestination=strDestination;
			object.sSource=strSource;
			object.iState=iState;
			object.iTransfer=iTransfer;
			object.lSize=lSize;
			object.fProcent=fProcent;
			object.sError=sError;
          if(object.fnCopyDirectory())//copy subdirectory
             return iRC3;
        }
        else
        {
       			CFile sourceFile;
				CFile destFile;
				CFileException ex;
		TCHAR szError[1024];
   // open the source file for reading

   if (!sourceFile.Open(strSource,
      CFile::modeRead | CFile::shareDenyWrite, &ex))
   {
      

     
      ex.GetErrorMessage(szError, 1024);
    
	   sError="Couldn't open source file"+strSource;
	   sError=sError+""+szError;
		 iState=4;//Task state:Failed
      return 1;
   }
   else
   {	//open the destination file for writing
      if (!destFile.Open(strDestination, CFile::modeWrite |
            CFile::shareExclusive | CFile::modeCreate, &ex))
      {
       
         ex.GetErrorMessage(szError, 1024);
    
         sError="Couldn't open destination file"+strDestination ;
		 sError=sError+""+szError;
		 iState=4;
         sourceFile.Close();
         return 1;
      }

      BYTE *pBuffer=new BYTE[1000];
	  DWORD dwRead;

      long lSum=0;
	  do
      {
		 
		   while(iState==0)//Task state:paused
		  {
           Sleep(300);
		  }
		  if (iState==3)//Task state:aborted
		  {
		
			destFile.Close();
            sourceFile.Close();
			return 0;
		  }
		   try
		  {
         dwRead = sourceFile.Read(pBuffer, 1000);
		  }
		  catch(CFileException* e)    // Catch File Exceptions
			{
      e->GetErrorMessage(szError, 1024);
       
		 sError="Couldn't read from source file"+strSource;
		 sError=sError+""+szError;
		 iState=4;//Task state failed
        
         sourceFile.Close();
     e->Delete();
	 return 1;
			 } 
       
         try{
         destFile.Write(pBuffer, dwRead);
		  }
	  catch(CFileException* e)    // Catch File Exceptions
			{
      e->GetErrorMessage(szError, 1024);
       
		 sError="Couldn't write to destination file"+strSource;
		 sError=sError+""+szError;
		 iState=4;//Task state failed
        
         destFile.Close();
     e->Delete();
	 return 1;
			 } 
		 lSum=lSum+1000;
		 	if (fProcent>100)
			{
				fProcent=100;
			}
		 if (lSum>=iTransfer)//Data "Packet" was transferred 
		 {
		
			double dHelp=lSum;
			
            fProcent=fProcent+(dHelp/lSize)*100;
	
			if (fProcent>100)
			{
				fProcent=100;
			}
			::PostMessage(hWindow, WM_TASKTRANSFER, lSum, iIndex);//actualize Progress parameter in task list
		 
		 Sleep(1000);
		 lSum=0;
         }
		
	
      }
      while (dwRead > 0);

      // Close both files

      destFile.Close();
      sourceFile.Close();
   }
 
   ::PostMessage(hWindow, WM_TASKTRANSFER, 0, iIndex);
 while(iState==0)//Task state:paused
		  {
           Sleep(300);
		  }
		  if (iState==3) //Task state:aborted
		  {
	
			destFile.Close();
            sourceFile.Close();
	
			return 0;
		  }



        }
      }
    } while(::FindNextFile(hFile, &FileInformation) == TRUE);//find next file/subdirectory in directory

    // Close handle
    ::FindClose(hFile);

    DWORD dwError = ::GetLastError();
    if(dwError != ERROR_NO_MORE_FILES)
      return dwError;
  }
  else
  {
	  
	  
  sError="Couldn't check file or directory in "+strSource;
	
  return 1;
  }

  
return 0;
}

int Task::fnCopyFile()
{
CString strSource;               // Source file
CString strDestination;          // Destination file
CString   strPattern;              // Pattern
HANDLE          hFile;                   // Handle to file
WIN32_FIND_DATA FileInformation;         // File information
strSource=sSource;
hFile = ::FindFirstFile(strSource, &FileInformation);
  if(hFile != INVALID_HANDLE_VALUE)
  {
   
  
strDestination=sDestination+"\\"+FileInformation.cFileName;
  }  
  else
  {
	  
	  
  sError="Couldn't open "+strSource;
	  
  return 1;
  }
  CloseHandle(hFile);
CFile sourceFile;
   CFile destFile;
    CFileException ex;
TCHAR szError[1024];
   // open the source file for reading

   if (!sourceFile.Open(strSource,
      CFile::modeRead | CFile::shareDenyWrite, &ex))
   {
      

      
      ex.GetErrorMessage(szError, 1024);
	  sError="Couldn't open source file"+strSource;
	  sError=sError+""+szError;
      iState=4;//Task state:failed
    // Couldn't open source file
  
      return 1;
   }
   else
   {
	  
      if (!destFile.Open(strDestination, CFile::modeWrite |
            CFile::shareExclusive | CFile::modeCreate, &ex))
      {
       
         ex.GetErrorMessage(szError, 1024);
       
		 sError="Couldn't open destination file"+strDestination;
		 sError=sError+""+szError;
		 iState=4;//Task state failed
        
         sourceFile.Close();
         return 1;
      }

     
      BYTE *pBuffer=new BYTE[1000];
	  DWORD dwRead;
     
      long lSum=0;

	  do
      {
		  while(iState==0)//Task state:paused
		  {
           Sleep(300);
		  }
		  if (iState==3) //Task state:aborted
		  {
			
			destFile.Close();
            sourceFile.Close();
			if(strDestination.Compare(strSource)!=0)//Source is not equal destination
			{
			::DeleteFile(strDestination);//delete destination file
			}
			return 1;
		  }
		  try
		  {
         dwRead = sourceFile.Read(pBuffer, 1000);
		  }
		  catch(CFileException* e)    // Catch File Exceptions
			{
      e->GetErrorMessage(szError, 1024);
       
		 sError="Couldn't read from source file"+strSource;
		 sError=sError+""+szError;
		 iState=4;//Task state failed
        
         sourceFile.Close();
     e->Delete();
	 return 1;
			 } 
		  try{
         destFile.Write(pBuffer, dwRead);
		  }
	  catch(CFileException* e)    // Catch File Exceptions
			{
      e->GetErrorMessage(szError, 1024);
       
		 sError="Couldn't write to destination file"+strSource;
		 sError=sError+""+szError;
		 iState=4;//Task state failed
        
         destFile.Close();
     e->Delete();
	 return 1;
			 } 
		 if (fProcent>100)
		 {
         fProcent=100;
         }
		 lSum=lSum+1000;
        
		 if (lSum>=iTransfer)//Data "packet" was transferred
		 {
		 ::PostMessage(hWindow, WM_TASKTRANSFER, lSum, iIndex);//actualize Progress parameter in task list
	
		double dHelp=lSum;
		fProcent=fProcent+(dHelp/lSize)*100;
			 
	
			 	if (fProcent>100)
			{
				fProcent=100;
			}

			
		 Sleep(1000);
		 lSum=0;
         }
	
      }
      while (dwRead > 0);
      fProcent=100;
       ::PostMessage(hWindow, WM_TASKTRANSFER, lSum, iIndex);
	 
      // Close both files

      destFile.Close();
      sourceFile.Close();
   }
iState=2;//Task state:finished
return 0;
}

long Task::fnGetDirectorySize()
{
CString     sSource2;               // Source file
CString     sPattern;              // Pattern
HANDLE          hFile,hFile2;     // Handles to file
WIN32_FIND_DATA FileInformation; 
  sSource2=sSource;

  sPattern =sSource + "\\*.*";
  
  hFile = ::FindFirstFile(sPattern, &FileInformation);//Find first file or subdirectory in directory
  if(hFile != INVALID_HANDLE_VALUE)
  {
    do
    {
      if(FileInformation.cFileName[0] != '.')
      {
        sSource2="";
     
        sSource2     = sSource + "\\" + FileInformation.cFileName;
        

        if(FileInformation.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)//directory
        {
         
			Task object;
			object.sSource=sSource2;
		object.lSize=lSize;
			if(object.fnGetDirectorySize())//get subdirectory size
             return iRC2;
        }
        else//file
        {
         DWORD dwSize;
     hFile2 = CreateFile(sSource2, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, 0, 0) ;
             dwSize = GetFileSize(hFile2, NULL) ;//get file size
				CloseHandle(hFile2);
    		lSize=lSize+dwSize;
        CString wynik2;
  
 
 
 


	
        }
      }
    } while(::FindNextFile(hFile, &FileInformation) == TRUE);//find next file or directory

 
    ::FindClose(hFile);

    DWORD dwError = ::GetLastError();
    if(dwError != ERROR_NO_MORE_FILES)
      return dwError;
  }
   else
  {
	  
	  
  sError="Couldn't check file or directory in "+sSource;
	
  return 1;
  }

return 0;
}

BOOL Task::fnDeleteDirectory(LPCTSTR lpszDir)//delete directory
{
int len = _tcslen(lpszDir);
  TCHAR *pszFrom = new TCHAR[len+2];
  _tcscpy(pszFrom, lpszDir);
  pszFrom[len] = 0;
  pszFrom[len+1] = 0;
  
  SHFILEOPSTRUCT fileop;
  fileop.hwnd   = NULL;    // no status display
  fileop.wFunc  = FO_DELETE;  // delete operation
  fileop.pFrom  = pszFrom;  // source file name as double null terminated string
  fileop.pTo    = NULL;    // no destination needed
  fileop.fFlags = FOF_NOCONFIRMATION|FOF_SILENT;  // do not prompt the user
  fileop.fFlags |= FOF_ALLOWUNDO;

  fileop.fAnyOperationsAborted = FALSE;
  fileop.lpszProgressTitle     = NULL;
  fileop.hNameMappings         = NULL;

  int ret = SHFileOperation(&fileop);
  delete [] pszFrom;  
  return (ret == 0);
}
