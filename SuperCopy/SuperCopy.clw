; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CSuperCopyDlg
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "SuperCopy.h"

ClassCount=3
Class1=CSuperCopyApp
Class2=CSuperCopyDlg

ResourceCount=4
Resource2=IDD_SUPERCOPY_DIALOG
Resource3=IDD_MESSAGEDLG
Resource1=IDR_MAINFRAME
Class3=CMsgDlg
Resource4=IDD_SUPERCOPY_DIALOG (English (U.S.))

[CLS:CSuperCopyApp]
Type=0
HeaderFile=SuperCopy.h
ImplementationFile=SuperCopy.cpp
Filter=N
LastObject=CSuperCopyApp

[CLS:CSuperCopyDlg]
Type=0
HeaderFile=SuperCopyDlg.h
ImplementationFile=SuperCopyDlg.cpp
Filter=D
LastObject=IDC_BNSTARTCOPY
BaseClass=CDialog
VirtualFilter=dWC



[DLG:IDD_SUPERCOPY_DIALOG]
Type=1
ControlCount=3
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_STATIC,static,1342308352
Class=CSuperCopyDlg

[DLG:IDD_SUPERCOPY_DIALOG (English (U.S.))]
Type=1
Class=CSuperCopyDlg
ControlCount=25
Control1=IDC_STATIC,button,1342177287
Control2=IDC_STATIC,static,1342308352
Control3=IDC_STSOURCE,static,1342312448
Control4=IDC_STATIC,static,1342308352
Control5=IDC_STDESTINATION,static,1342312448
Control6=IDC_STATIC,static,1342308352
Control7=IDC_STSTATE,static,1342312448
Control8=IDC_STATIC,static,1342308352
Control9=IDC_STATIC,static,1342308352
Control10=IDC_EDIT1,edit,1350631552
Control11=IDC_SPIN1,msctls_updown32,1342177334
Control12=IDC_STERROR,static,1342312448
Control13=IDC_BNSTARTCOPY,button,1342242816
Control14=IDC_BNSTOPCOPY,button,1342242816
Control15=IDC_BNABORTCOPY,button,1342242816
Control16=IDC_TREE1,SysTreeView32,1350631431
Control17=IDC_TREE2,SysTreeView32,1350631431
Control18=IDC_BNSelectFile,button,1342242816
Control19=IDC_BNSelectSourceDriveFolder,button,1342242816
Control20=IDC_BNSELECTDRIVE,button,1342242816
Control21=IDC_BNCREATEDIR,button,1342242816
Control22=IDC_LIST1,SysListView32,1350631425
Control23=IDC_BNCREATETASK,button,1342242816
Control24=IDC_EDIT2,edit,1350631552
Control25=IDC_EDIT3,edit,1350631552

[DLG:IDD_MESSAGEDLG]
Type=1
Class=CMsgDlg
ControlCount=4
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_STATIC,static,1342308352
Control4=IDC_EDIT1,edit,1350631552

[CLS:CMsgDlg]
Type=0
HeaderFile=MsgDlg.h
ImplementationFile=MsgDlg.cpp
BaseClass=CDialog
Filter=D
LastObject=CMsgDlg
VirtualFilter=dWC

