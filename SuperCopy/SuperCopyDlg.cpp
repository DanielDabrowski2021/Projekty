// SuperCopyDlg.cpp : implementation file
//

#include "stdafx.h"
#include "Task.h"
#include "SuperCopy.h"
#include "MsgDlg.h"
#include "SuperCopyDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif
int iListColumnCreated=0;////indicate if task list was created
int iTreeListCreated=0;//indicate if left tree was created
int iTree2ListCreated=0;//indicate if right tree was created
const int iTaskArraySize=50;//size of Task array
Task *pTaskPointer=new Task[iTaskArraySize];//Task array
int Task::iTaskCount=0;//number of created tasks
int iRC;
int iCI=0;//index of task in control panel
CImageList ImageList1;//Image list for left tree
CImageList ImageList2;//Image list for right tree
/////////////////////////////////////////////////////////////////////////////
// CSuperCopyDlg dialog

CSuperCopyDlg::CSuperCopyDlg(CWnd* pParent )
	: CDialog(CSuperCopyDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CSuperCopyDlg)
	m_sDestinationFolder = _T("");
	m_sSourceF = _T("");
	m_sSTSource = _T("");
	m_sSTDestination = _T("");
	m_sSTState = _T("");
	m_iTransfer = 0;
	m_sError = _T("");
	//}}AFX_DATA_INIT

	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CSuperCopyDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
//{{AFX_DATA_MAP(CSuperCopyDlg)
	DDX_Control(pDX, IDC_TREE2, m_CTreeCtrl2);
	DDX_Control(pDX, IDC_TREE1, m_CTreeCtrl1);
	DDX_Control(pDX, IDC_SPIN1, m_CSpinButtonCtrl);
	DDX_Control(pDX, IDC_LIST1, m_CListCtrlTaskList);
	DDX_Text(pDX, IDC_EDIT3, m_sDestinationFolder);
	DDX_Text(pDX, IDC_EDIT2, m_sSourceF);
	DDX_Text(pDX, IDC_STSOURCE, m_sSTSource);
	DDX_Text(pDX, IDC_STDESTINATION, m_sSTDestination);
	DDX_Text(pDX, IDC_STSTATE, m_sSTState);
	DDX_Text(pDX, IDC_EDIT1, m_iTransfer);
	DDX_Text(pDX, IDC_STERROR, m_sError);
	//}}AFX_DATA_MAP

}

BEGIN_MESSAGE_MAP(CSuperCopyDlg, CDialog)
//{{AFX_MSG_MAP(CSuperCopyDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BNCREATEDIR, OnBncreatedir)
	ON_BN_CLICKED(IDC_BNSELECTDRIVE, OnBnselectdrive)
	ON_BN_CLICKED(IDC_BNSelectSourceDriveFolder, OnBNSelectSourceDriveFolder)
	ON_BN_CLICKED(IDC_BNSelectFile, OnBNSelectFile)
	ON_BN_CLICKED(IDC_BNCREATETASK, OnBncreatetask)
	ON_NOTIFY(NM_CLICK, IDC_LIST1, OnClickList1)
	ON_BN_CLICKED(IDC_BNSTARTCOPY, OnBnstartcopy)
	ON_BN_CLICKED(IDC_BNSTOPCOPY, OnBnstopcopy)
	ON_BN_CLICKED(IDC_BNABORTCOPY, OnBnabortcopy)
	ON_NOTIFY(NM_CLICK, IDC_TREE1, OnClickTree1)
	ON_NOTIFY(NM_CLICK, IDC_TREE2, OnClickTree2)
	ON_NOTIFY(NM_RCLICK, IDC_TREE1, OnRclickTree1)
	ON_NOTIFY(NM_RCLICK, IDC_TREE2, OnRclickTree2)
	ON_WM_DESTROY()
	//}}AFX_MSG_MAP

	ON_MESSAGE(WM_TASKCHANGE, OnTaskchange)
	ON_MESSAGE(WM_TASKTRANSFER, OnTasktransfer)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSuperCopyDlg message handlers



BOOL CSuperCopyDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	SetIcon(m_hIcon, TRUE);		
	SetIcon(m_hIcon, FALSE);	


	
	return TRUE;  
}



void CSuperCopyDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); 

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

	
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

	
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

HCURSOR CSuperCopyDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CSuperCopyDlg::OnBncreatedir() 
{
//Create directory
CString sDirectory;
if (m_dMsgDlg.DoModal( ) == IDOK)
{
sDirectory=m_dMsgDlg.m_sCreatedDirectory;
::CreateDirectory(sDirectory, 0);

}	
}

void CSuperCopyDlg::OnBnselectdrive() 
{
//Select directory or drive	
CString		sFolder;
	LPMALLOC	pMalloc;
char pszBuffer[MAX_PATH];
    // Gets the Shell's default allocator
    if (::SHGetMalloc(&pMalloc) == NOERROR)
    {
        BROWSEINFO bi;
        
        LPITEMIDLIST pidl;

        bi.hwndOwner = GetSafeHwnd();
        bi.pidlRoot = NULL;
        bi.pszDisplayName = pszBuffer;
        bi.lpszTitle = _T("Select a directory...");
        bi.ulFlags = BIF_RETURNFSANCESTORS | BIF_RETURNONLYFSDIRS;
        bi.lpfn = NULL;
        bi.lParam = 0;

        // This next call issues the dialog box.
        if ((pidl = ::SHBrowseForFolder(&bi)) != NULL)
        {
            if (::SHGetPathFromIDList(pidl, pszBuffer))
            { 
	            // At this point pszBuffer contains the selected path
				sFolder = pszBuffer;
            }

            // Free the PIDL allocated by SHBrowseForFolder.
            pMalloc->Free(pidl);
        }
        // Release the shell's allocator.
        pMalloc->Release();


if (iTree2ListCreated==0)
{
	//Create image list for right tree
		ImageList2.Create(13, 13, FALSE, 4, 0);
   HICON hIcon = ::LoadIcon(AfxGetResourceHandle(),
      MAKEINTRESOURCE(IDI_ICON1));
   ImageList2.Add(hIcon);
   hIcon = ::LoadIcon(AfxGetResourceHandle(),
      MAKEINTRESOURCE(IDI_ICON2));
   ImageList2.Add(hIcon);
   hIcon = ::LoadIcon(AfxGetResourceHandle(),
      MAKEINTRESOURCE(IDI_ICON3));
   ImageList2.Add(hIcon);
   hIcon = ::LoadIcon(AfxGetResourceHandle(),
      MAKEINTRESOURCE(IDI_ICON4));
   ImageList2.Add(hIcon); 
    m_CTreeCtrl2.SetImageList(&ImageList2, TVSIL_NORMAL);
	 iTree2ListCreated=1;
}

m_CTreeCtrl2.DeleteAllItems();
//////////////Create root item

	 TVITEM tvItem;
     tvItem.mask =
          TVIF_TEXT | TVIF_IMAGE | TVIF_SELECTEDIMAGE;

	 tvItem.pszText=pszBuffer;
 	 tvItem.cchTextMax = 4;
     tvItem.iImage = 0;
     tvItem.iSelectedImage = 3;
     TVINSERTSTRUCT tvInsert;
     tvInsert.hParent = TVI_ROOT;
     tvInsert.hInsertAfter = TVI_FIRST;
     tvInsert.item = tvItem;

	 HTREEITEM hRoot = m_CTreeCtrl2.InsertItem(&tvInsert);
/////////
	 

CString source=sFolder;


CString     strSource;               // Source file
        
  CString     strPattern;              // Pattern
  HANDLE          hFile;                   // Handle to file
  WIN32_FIND_DATA FileInformation; 
 
 int iHelp2 = strlen(source);
if (iHelp2<=3)//drive was selected
{
strPattern = source + "*.*";
}
else
{
  strPattern = source + "\\*.*";
} 
  hFile = ::FindFirstFile(strPattern, &FileInformation);
  //find first file or directory
  if(hFile != INVALID_HANDLE_VALUE)
  {
    do
    {
      if(FileInformation.cFileName[0] != '.')
      {
        strSource="";
        
        strSource=FileInformation.cFileName;
        tvItem.pszText = FileInformation.cFileName;
     tvItem.cchTextMax = 220;
	  if(FileInformation.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
        {
          // Create directory item
		tvItem.iImage = 2;
        }
	  else
	  {
		  //Create file item
     tvItem.iImage = 1;
	  }
	  //Create item
	 tvItem.iSelectedImage = 3;
     tvInsert.hParent = hRoot;
     tvInsert.hInsertAfter = TVI_LAST;
     tvInsert.item = tvItem;
     HTREEITEM hChildItem = m_CTreeCtrl2.InsertItem(&tvInsert);
  		////////////////////
        }
      
    }while(::FindNextFile(hFile, &FileInformation) == TRUE);
    }
  else
  {
	  CString sMessage;
	  sMessage="Couldn't check "+strPattern;
  MessageBox(sMessage);
  }
	  // Close handle
    ::FindClose(hFile);

 


	 m_CTreeCtrl2.SortChildren(hRoot);


    }

	GetDlgItem(IDC_EDIT3)->SetWindowText(sFolder);	
m_sDestinationFolder=sFolder;
}

void CSuperCopyDlg::OnBNSelectSourceDriveFolder() 
{
	// Browse for drive or folder
CString		sFolder;
	LPMALLOC	pMalloc;
char pszBuffer[MAX_PATH];
    // Gets the Shell's default allocator
    if (::SHGetMalloc(&pMalloc) == NOERROR)
    {
        BROWSEINFO bi;
        
        LPITEMIDLIST pidl;

        bi.hwndOwner = GetSafeHwnd();
        bi.pidlRoot = NULL;
        bi.pszDisplayName = pszBuffer;
        bi.lpszTitle = _T("Select a directory...");
        bi.ulFlags = BIF_RETURNFSANCESTORS | BIF_RETURNONLYFSDIRS;
        bi.lpfn = NULL;
        bi.lParam = 0;

        // This next call issues the dialog box.
        if ((pidl = ::SHBrowseForFolder(&bi)) != NULL)
        {
            if (::SHGetPathFromIDList(pidl, pszBuffer))
            { 
	            // At this point pszBuffer contains the selected path
				sFolder = pszBuffer;
            }

            // Free the PIDL allocated by SHBrowseForFolder.
            pMalloc->Free(pidl);
        }
        // Release the shell's allocator.
        pMalloc->Release();
		
if (iTreeListCreated==0)
{
	//Create image list for left tree
		ImageList1.Create(13, 13, FALSE, 4, 0);
   HICON hIcon = ::LoadIcon(AfxGetResourceHandle(),
      MAKEINTRESOURCE(IDI_ICON1));
   ImageList1.Add(hIcon);
   hIcon = ::LoadIcon(AfxGetResourceHandle(),
      MAKEINTRESOURCE(IDI_ICON2));
   ImageList1.Add(hIcon);
   hIcon = ::LoadIcon(AfxGetResourceHandle(),
      MAKEINTRESOURCE(IDI_ICON3));
   ImageList1.Add(hIcon);
   hIcon = ::LoadIcon(AfxGetResourceHandle(),
      MAKEINTRESOURCE(IDI_ICON4));
   ImageList1.Add(hIcon); 
     m_CTreeCtrl1.SetImageList(&ImageList1, TVSIL_NORMAL);
	 iTreeListCreated=1;
}



m_CTreeCtrl1.DeleteAllItems();
//////////////////Create root item
	 TVITEM tvItem;
     tvItem.mask =
          TVIF_TEXT | TVIF_IMAGE | TVIF_SELECTEDIMAGE;
	 tvItem.pszText=pszBuffer;
 	 tvItem.cchTextMax = 4;
     tvItem.iImage = 0;
     tvItem.iSelectedImage = 3;
     TVINSERTSTRUCT tvInsert;
     tvInsert.hParent = TVI_ROOT;
     tvInsert.hInsertAfter = TVI_FIRST;
     tvInsert.item = tvItem;

	 HTREEITEM hRoot = m_CTreeCtrl1.InsertItem(&tvInsert);
//////////////////	
	 
CString source=sFolder;
CString     strSource;               // Source file
         
  CString     strPattern;              // Pattern
  HANDLE          hFile;                   // Handle to file
  WIN32_FIND_DATA FileInformation; 
 
 int iHelp2 = strlen(source);
if (iHelp2<=3)//drive was selected
{
strPattern = source + "*.*";
}
else
{
  strPattern = source + "\\*.*";
} 

 
 
  hFile = ::FindFirstFile(strPattern, &FileInformation);
  if(hFile != INVALID_HANDLE_VALUE)
  {
    do
    {
      if(FileInformation.cFileName[0] != '.')
      {
        strSource="";
        
        strSource=FileInformation.cFileName;
        tvItem.pszText = FileInformation.cFileName;
     tvItem.cchTextMax = 220;
	  if(FileInformation.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
        {
          // Create directory item
		tvItem.iImage = 2;
        }
	  else
	  {//Create file item
     tvItem.iImage = 1;
	  }
	 tvItem.iSelectedImage = 3;
     tvInsert.hParent = hRoot;
     tvInsert.hInsertAfter = TVI_LAST;
     tvInsert.item = tvItem;
     HTREEITEM hChildItem = m_CTreeCtrl1.InsertItem(&tvInsert);
  
        }
      
    }while(::FindNextFile(hFile, &FileInformation) == TRUE);
    }
  else
  {
	  CString sMessage;
	  sMessage="Couldn't check "+strPattern;
  MessageBox(sMessage);
  }
	  // Close handle
    ::FindClose(hFile);

 


	 m_CTreeCtrl1.SortChildren(hRoot);
}


	
    

	GetDlgItem(IDC_EDIT2)->SetWindowText(sFolder);	
m_sSourceF=sFolder;	

}

void CSuperCopyDlg::OnBNSelectFile() 
{
	//Select file
CFileDialog m_ldFile(TRUE);

	if (m_ldFile.DoModal() == IDOK)
     {
         // Get the filename selected
	
         m_sSourceF =m_ldFile.GetPathName();
		
         UpdateData(FALSE);
     }	
}

void CSuperCopyDlg::OnBncreatetask() 
{
m_CSpinButtonCtrl.SetRange(1,10000);//set speed limit range

if (iListColumnCreated==0)
{
	//Create task list
	LV_COLUMN lvColumn;
    lvColumn.mask = LVCF_FMT | LVCF_WIDTH | LVCF_TEXT | LVCF_SUBITEM;
    lvColumn.fmt = LVCFMT_CENTER;
    lvColumn.cx = 75;
    lvColumn.iSubItem = 0;
    lvColumn.pszText = "Nr";
    m_CListCtrlTaskList.InsertColumn(0, &lvColumn);
    lvColumn.iSubItem = 1;
    lvColumn.pszText = "Source";
    m_CListCtrlTaskList.InsertColumn(1, &lvColumn);
    lvColumn.iSubItem = 2;
    lvColumn.pszText = "Destination";
    m_CListCtrlTaskList.InsertColumn(2, &lvColumn);
	lvColumn.iSubItem = 3;
    lvColumn.pszText = "Speed limit";
    m_CListCtrlTaskList.InsertColumn(3, &lvColumn);
    lvColumn.iSubItem = 4;
    lvColumn.pszText = "State";
    m_CListCtrlTaskList.InsertColumn(4, &lvColumn);
    lvColumn.iSubItem = 5; 
	lvColumn.pszText = "Progress";
    m_CListCtrlTaskList.InsertColumn(5, &lvColumn);	
iListColumnCreated=1;
}
UpdateData(TRUE);
if ((m_sSourceF==""))
{
MessageBox("Select source file or directory");	
}
if ((m_sDestinationFolder==""))
{
MessageBox("Select destination directory");	
}
if (Task::iTaskCount<iTaskArraySize-1)//Task array isn't full
{        
  CString     strPattern;              // Pattern
  HANDLE          hFile;                   // Handle to file
  WIN32_FIND_DATA FileInformation; 
  hFile = ::FindFirstFile(m_sSourceF, &FileInformation);
  if(hFile != INVALID_HANDLE_VALUE)
  {
    
      if(FileInformation.cFileName[0] != '.')
      {
		  HWND hWnd = GetSafeHwnd();
Task::iTaskCount++;
int iCurrentIndex=Task::iTaskCount;
///set task attributes
pTaskPointer[iCurrentIndex].iIndex=iCurrentIndex;
pTaskPointer[iCurrentIndex].hWindow=hWnd;
pTaskPointer[iCurrentIndex].iState=0;
UpdateData(TRUE);
pTaskPointer[iCurrentIndex].sSource=m_sSourceF;
pTaskPointer[iCurrentIndex].fProcent=0;
pTaskPointer[iCurrentIndex].sError="";

///
Task* pNewTask =&pTaskPointer[iCurrentIndex];
////set task item	
LV_ITEM lvItem;
    lvItem.mask = LVIF_TEXT | LVIF_IMAGE | LVIF_STATE;
    lvItem.state = 0;     
    lvItem.stateMask = 0; 
    lvItem.iImage = 0;
    lvItem.iItem = iCurrentIndex;
    lvItem.iSubItem = 0;
 

	char bufor[4];
	sprintf(bufor,"%d",iCurrentIndex);
	lvItem.pszText =bufor;
	m_CListCtrlTaskList.InsertItem(&lvItem);
    m_CListCtrlTaskList.SetItemText(iCurrentIndex-1, 1,m_sSourceF);
    m_CListCtrlTaskList.SetItemText(iCurrentIndex-1, 2,m_sDestinationFolder);

	m_CListCtrlTaskList.SetItemText(iCurrentIndex-1, 3,"0kB/s");
	m_CListCtrlTaskList.SetItemText(iCurrentIndex-1, 4,"Paused");
	m_CListCtrlTaskList.SetItemText(iCurrentIndex-1,5,"0%");
	/////
      if(FileInformation.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
	  {
		//directory task
	 

	pTaskPointer[iCurrentIndex].sDestination=m_sDestinationFolder+"\\"+FileInformation.cFileName;
	 AfxBeginThread(Task::fnCreateDirectoryTask,pNewTask);
	  }
	  else
	  {
		  //file task

		  DWORD dwSize;
	
		  hFile = CreateFile(m_sSourceF, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, 0, 0) ;
		    dwSize=GetFileSize(hFile, NULL);
	 
        
         CloseHandle(hFile) ;
      
		  pTaskPointer[iCurrentIndex].lSize=dwSize;
		 
     pTaskPointer[iCurrentIndex].sDestination=m_sDestinationFolder;
AfxBeginThread(Task::fnCreateFileTask,pNewTask);
	  }
	  }
	}
  else
  {
	  CString sHelp;
	  sHelp="Couldn't open "+m_sSourceF;
  MessageBox(sHelp);
  return ;
  }
  CloseHandle(hFile) ;
UpdateData(FALSE);
}
}

void CSuperCopyDlg::OnClickList1(NMHDR* pNMHDR, LRESULT* pResult) 
{
//get task for control panel
POSITION pos = m_CListCtrlTaskList.GetFirstSelectedItemPosition();
if (pos == NULL)
{

}
   
else
{
	int iNextPos=m_CListCtrlTaskList.GetNextSelectedItem(pos);
CString sHelpString=m_CListCtrlTaskList.GetItemText(iNextPos,0);
int iHelp;
sscanf(sHelpString,"%d",&iHelp);
iCI=iHelp;
m_sSTSource=pTaskPointer[iCI].sSource;
m_sSTDestination=pTaskPointer[iCI].sDestination;
m_sError=pTaskPointer[iCI].sError;
//get task attributes for control panel
if (pTaskPointer[iCI].iState==0)
{
m_sSTState="Paused";
m_sError="";
UpdateData(FALSE);
}
if (pTaskPointer[iCI].iState==1)
{
m_sSTState="Running";
m_sError="";
UpdateData(FALSE);
}
if (pTaskPointer[iCI].iState==2)
{

m_sSTState="Finished";
m_sError="";
UpdateData(FALSE);

}
if (pTaskPointer[iCI].iState==3)
{
m_sSTState="Aborted";
m_sError="";
UpdateData(FALSE);
}
if (pTaskPointer[iCI].iState==4)
{
m_sSTState="Failed";
UpdateData(FALSE);
}

UpdateData(FALSE);

}	
	*pResult = 0;
}

void CSuperCopyDlg::OnBnstartcopy() 
{
	// start task
UpdateData(TRUE);
if (pTaskPointer[iCI].iState==2 || pTaskPointer[iCI].iState==3)
{//Task state: finished or aborted
return;
}
if (m_iTransfer==0)
{
MessageBox("Select speed limit");
return;
}

//set task attributes

pTaskPointer[iCI].iTransfer=m_iTransfer*1024;
pTaskPointer[iCI].iState=1;
m_CListCtrlTaskList.SetItemText(iCI-1, 4,"Running");
CString sHelp;
sHelp.Format("%d kB/s",m_iTransfer);
m_CListCtrlTaskList.SetItemText(iCI-1,3,sHelp);

UpdateData(FALSE);	
}

void CSuperCopyDlg::OnBnstopcopy() 
{
if (pTaskPointer[iCI].iState==2 || pTaskPointer[iCI].iState==3)
{//Task state: finished or aborted
return;
}
//stop task
UpdateData(TRUE);
int iHelpindex=iCI;
pTaskPointer[iCI].iState=0;	
m_CListCtrlTaskList.SetItemText(iCI-1, 4,"Paused");
UpdateData(FALSE);	
}

void CSuperCopyDlg::OnBnabortcopy() 
{
//abort task ,can not be started again
if (pTaskPointer[iCI].iState==2)//Task state: finished
{
return;
}
CString sReturn;
sReturn = MessageBox("Are you sure?","Warning",MB_YESNO | MB_ICONSTOP);
if(sReturn==IDYES)
{ 
	UpdateData(TRUE);
int iHelpindex=iCI;
pTaskPointer[iCI].iState=3;
m_CListCtrlTaskList.SetItemText(iCI-1, 4,"Aborted");	
}
}
LONG CSuperCopyDlg::OnTaskchange(WPARAM wParam, LPARAM lParam)
{
//Task state was changed
int iHelpindex=(int)lParam;
m_sError="";
 UpdateData(FALSE);
//actualize task list
if (pTaskPointer[iHelpindex].iState==0)
{

m_CListCtrlTaskList.SetItemText(iHelpindex-1, 4,"Paused");
//actualize control panel 
if (iCI==iHelpindex)
 {
 m_sSTState="Paused";
 UpdateData(FALSE);

 }

}
if (pTaskPointer[iHelpindex].iState==1)
{

m_CListCtrlTaskList.SetItemText(iHelpindex-1, 4,"Running");
if (iCI==iHelpindex)
 {
 m_sSTState="Running";
 UpdateData(FALSE);

 }
}
if (pTaskPointer[iHelpindex].iState==2)
{

m_CListCtrlTaskList.SetItemText(iHelpindex-1, 4,"Finished");
m_CListCtrlTaskList.SetItemText(iHelpindex-1, 5,"100%");
if (iCI==iHelpindex)
 {
 m_sSTState="Finished";
 UpdateData(FALSE);

 }
}
if (pTaskPointer[iHelpindex].iState==3)
{
m_CListCtrlTaskList.SetItemText(iHelpindex-1, 4,"Aborted");
if (iCI==iHelpindex)
 {
 m_sSTState="Aborted";
 UpdateData(FALSE);

 }
}
if (pTaskPointer[iHelpindex].iState==4)
{
m_CListCtrlTaskList.SetItemText(iHelpindex-1, 4,"Failed");
m_sError=pTaskPointer[iHelpindex].sError;
if (iCI==iHelpindex)
 {
 m_sSTState="Failed";
 UpdateData(FALSE);

 }
}

	return 0;

   

}
LONG CSuperCopyDlg::OnTasktransfer(WPARAM wParam, LPARAM lParam)
{
//data "packet" was transferred
float fHelp=(float)wParam;
int iHelpindex=lParam;
CString sHelp;
sHelp.Format("%0.1f",pTaskPointer[iHelpindex].fProcent);
sHelp=sHelp+"%";
//actualize task list
m_CListCtrlTaskList.SetItemText(iHelpindex-1,5,sHelp);
UpdateData(FALSE);
return 0;
}

void CSuperCopyDlg::OnClickTree1(NMHDR* pNMHDR, LRESULT* pResult) 
{
//Get item path
	CString sHelp;
CString sArray[100];

int iCount=0;
	HTREEITEM hItem=m_CTreeCtrl1.GetSelectedItem();
	HTREEITEM hRoot=m_CTreeCtrl1.GetRootItem();
	CString sRootText=m_CTreeCtrl1.GetItemText(hRoot);

int iHelp2 = strlen(sRootText);

if (iHelp2<=3)//drive was selected
{
sRootText.Remove('\\');
m_CTreeCtrl1.SetItemText(hRoot,sRootText);
}

	CString sSelected=m_CTreeCtrl1.GetItemText(hItem);
	while(hItem!=NULL)
	{
	hItem=m_CTreeCtrl1.GetParentItem(hItem);
	sArray[iCount]=m_CTreeCtrl1.GetItemText(hItem);

	iCount++;
	}
	int iCount2=iCount-2;
	sHelp="";


	while(iCount2>=0)
	{
	sHelp=sHelp+sArray[iCount2];
	sHelp=sHelp+"\\";
	iCount2--;
    } 
	sHelp=sHelp+sSelected;

	m_sSourceF=sHelp;

	UpdateData(FALSE);

	*pResult = 0;
}

void CSuperCopyDlg::OnClickTree2(NMHDR* pNMHDR, LRESULT* pResult) 
{
//get item path	
CString sHelp;
CString sArray[100];

int iCount=0;
	HTREEITEM hItem=m_CTreeCtrl2.GetSelectedItem();
		HTREEITEM hRoot=m_CTreeCtrl2.GetRootItem();
	CString sSelected=m_CTreeCtrl2.GetItemText(hItem);
		CString sRootText=m_CTreeCtrl2.GetItemText(hRoot);
int iHelp2 = strlen(sRootText);
if (iHelp2<=3) //drive was selected
{
sRootText.Remove('\\');
m_CTreeCtrl2.SetItemText(hRoot,sRootText);
}
	while(hItem!=NULL)
	{
	hItem=m_CTreeCtrl2.GetParentItem(hItem);
	sArray[iCount]=m_CTreeCtrl2.GetItemText(hItem);
	iCount++;
	}
	int iCount2=iCount-2;
	sHelp="";
	while(iCount2>=0)
	{
	sHelp=sHelp+sArray[iCount2];
	sHelp=sHelp+"\\";
	iCount2--;
    } 
	sHelp=sHelp+sSelected;
	m_sDestinationFolder=sHelp;
	UpdateData(FALSE);	
	*pResult = 0;
}

void CSuperCopyDlg::OnRclickTree1(NMHDR* pNMHDR, LRESULT* pResult) 
{
//create item tree
		CString sHelp;
CString sArray[100];
int iCount=0;
	HTREEITEM hItem=m_CTreeCtrl1.GetSelectedItem();
	HTREEITEM hSelected=m_CTreeCtrl1.GetSelectedItem();
	CString sActual=m_CTreeCtrl1.GetItemText(hItem);
		TVITEM tvItem;
     tvItem.mask =
          TVIF_TEXT | TVIF_IMAGE | TVIF_SELECTEDIMAGE;
//get item path
	 while(hItem!=NULL)
	{
	hItem=m_CTreeCtrl1.GetParentItem(hItem);
	sArray[iCount]=m_CTreeCtrl1.GetItemText(hItem);
	iCount++;
	}
	int iCount2=iCount-2;
	sHelp="";
	while(iCount2>=0)
	{
	sHelp=sHelp+sArray[iCount2];
	sHelp=sHelp+"\\";
	iCount2--;
    } 
	sHelp=sHelp+sActual;

	TVINSERTSTRUCT tvInsert;
	CString source=sHelp;

CString     strSource;               // Source file

  CString     strPattern;              // Pattern
  HANDLE          hFile;                   // Handle to file
  WIN32_FIND_DATA FileInformation; 
 
 

  strPattern = source + "\\*.*";
 
  hFile = ::FindFirstFile(strPattern, &FileInformation);//find files and subdirectories
  if(hFile != INVALID_HANDLE_VALUE)
  {
    do
    {
      if(FileInformation.cFileName[0] != '.')
      {
        strSource="";
         if(FileInformation.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
		 {
         tvItem.iImage = 2;//create directory item
		 }
		  else
	  {
     tvItem.iImage = 1; //create file item
	  }
        strSource=FileInformation.cFileName;
        tvItem.pszText = FileInformation.cFileName;
     tvItem.cchTextMax = 220;
     
     tvItem.iSelectedImage = 4;
     tvInsert.hParent = hSelected;
     tvInsert.hInsertAfter = TVI_LAST;
     tvInsert.item = tvItem;
     HTREEITEM hChildItem = m_CTreeCtrl1.InsertItem(&tvInsert);
  	
        }
      
    }while(::FindNextFile(hFile, &FileInformation) == TRUE);//find next file
    }
  else
  {
	  CString sHelp;
	  sHelp="Couldn't open some object in"+strPattern;
  MessageBox(sHelp);
  return ;
  }
	  // Close handle
    ::FindClose(hFile);
m_CTreeCtrl1.SortChildren(hSelected);	
	*pResult = 0;
}

void CSuperCopyDlg::OnRclickTree2(NMHDR* pNMHDR, LRESULT* pResult) 
{
//create item tree
		CString sHelp;
CString sArray[100];
int iCount=0;
	HTREEITEM hItem=m_CTreeCtrl2.GetSelectedItem();
	HTREEITEM hSelected=m_CTreeCtrl2.GetSelectedItem();
	CString sActual=m_CTreeCtrl2.GetItemText(hItem);
		TVITEM tvItem;
     tvItem.mask =
          TVIF_TEXT | TVIF_IMAGE | TVIF_SELECTEDIMAGE;
//get item path
	 while(hItem!=NULL)
	{
	hItem=m_CTreeCtrl2.GetParentItem(hItem);
	sArray[iCount]=m_CTreeCtrl2.GetItemText(hItem);
	iCount++;
	}
	int iCount2=iCount-2;
	sHelp="";
	while(iCount2>=0)
	{
	sHelp=sHelp+sArray[iCount2];
	sHelp=sHelp+"\\";

	iCount2--;
    } 
	sHelp=sHelp+sActual;

	TVINSERTSTRUCT tvInsert;


	CString source=sHelp;
CString     strSource;               // Source file
          
  CString     strPattern;              // Pattern
  HANDLE          hFile;                   // Handle to file
  WIN32_FIND_DATA FileInformation; 
 
 

  strPattern = source + "\\*.*";
 
  hFile = ::FindFirstFile(strPattern, &FileInformation);//find files and subdirectories
  if(hFile != INVALID_HANDLE_VALUE)
  {
    do
    {
      if(FileInformation.cFileName[0] != '.')
      {
        strSource="";
         if(FileInformation.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
		 {
         tvItem.iImage = 2;//create directory item
		 }
		  else
	  {
     tvItem.iImage = 1;//create file item
	  }
        strSource=FileInformation.cFileName;
        tvItem.pszText = FileInformation.cFileName;
     tvItem.cchTextMax = 220;
    
     tvItem.iSelectedImage = 4;
     tvInsert.hParent = hSelected;
     tvInsert.hInsertAfter = TVI_LAST;
     tvInsert.item = tvItem;
     HTREEITEM hChildItem = m_CTreeCtrl2.InsertItem(&tvInsert);
  
        }
      
    }while(::FindNextFile(hFile, &FileInformation) == TRUE);
    }
   else
  {
	  CString sHelp;
	  sHelp="Couldn't open some object in"+strPattern;
  MessageBox(sHelp);
  return ;
  }
	  // Close handle
    ::FindClose(hFile);
m_CTreeCtrl2.SortChildren(hSelected);	
	*pResult = 0;
}

void CSuperCopyDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	for (int i=1;i<Task::iTaskCount+1;i++)
	{
    pTaskPointer[i].iState=3;
	}
	Sleep(1000);
	
}
