// Task.h: interface for the Task class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_TASK_H__39B20C00_1F0C_11DB_82A9_0050BA2BF6E7__INCLUDED_)
#define AFX_TASK_H__39B20C00_1F0C_11DB_82A9_0050BA2BF6E7__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif 

class Task  
{
public:
	CString sError;//Error message
	BOOL fnDeleteDirectory(LPCTSTR lpszDir);
	long fnGetDirectorySize();
	int fnCopyFile();
	int fnCopyDirectory();
	static UINT fnCreateDirectoryTask(LPVOID pParam);
	static UINT fnCreateFileTask(LPVOID pParam);
	int iTransfer;//Speed limit
	HWND hWindow;//handler to window
	long lSize;//size of file or files in directory
	CString sDestination;//destination
	CString sSource;//source
	float fProcent;//progress
	int iIndex;//task index
	int static iTaskCount;//number of created tasks
	int iState;//task state
	

	Task();
	virtual ~Task();

};

#endif 
