// SuperCopyDlg.h : header file
//

#if !defined(AFX_SUPERCOPYDLG_H__BB7BD965_1EED_11DB_82A9_0050BA2BF6E7__INCLUDED_)
#define AFX_SUPERCOPYDLG_H__BB7BD965_1EED_11DB_82A9_0050BA2BF6E7__INCLUDED_

#include "MsgDlg.h"	// Added by ClassView
#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CSuperCopyDlg dialog
const WM_TASKTRANSFER = WM_USER + 200;
const WM_TASKCHANGE=WM_USER+300;

class CSuperCopyDlg : public CDialog
{
// Construction
public:
	
	
	CSuperCopyDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CSuperCopyDlg)
	enum { IDD = IDD_SUPERCOPY_DIALOG };
	CTreeCtrl	m_CTreeCtrl2;
	CTreeCtrl	m_CTreeCtrl1;
	CSpinButtonCtrl	m_CSpinButtonCtrl;
	CListCtrl	m_CListCtrlTaskList;
	CString	m_sDestinationFolder;
	CString	m_sSourceF;
	CString	m_sSTSource;
	CString	m_sSTDestination;
	CString	m_sSTState;
	int		m_iTransfer;
	CString	m_sError;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CSuperCopyDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CSuperCopyDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnBncreatedir();
	afx_msg void OnBnselectdrive();
	afx_msg void OnBNSelectSourceDriveFolder();
	afx_msg void OnBNSelectFile();
	afx_msg void OnBncreatetask();
	afx_msg void OnClickList1(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnBnstartcopy();
	afx_msg void OnBnstopcopy();
	afx_msg void OnBnabortcopy();
	afx_msg LONG OnTaskchange(WPARAM wParam, LPARAM lParam);
	afx_msg LONG OnTasktransfer(WPARAM wParam, LPARAM lParam);

	afx_msg void OnClickTree1(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnClickTree2(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnRclickTree1(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnRclickTree2(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnDestroy();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
private:
	CMsgDlg m_dMsgDlg;
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_SUPERCOPYDLG_H__BB7BD965_1EED_11DB_82A9_0050BA2BF6E7__INCLUDED_)
