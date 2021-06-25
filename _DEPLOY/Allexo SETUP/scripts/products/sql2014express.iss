// requires Windows 7, Windows Server 2003, Windows Server 2008, Windows Server 2008 R2, Windows Vista, Windows XP
// requires Microsoft .NET Framework 3.5 SP 1 or later
// requires Windows Installer 4.5 or later
// SQL Server Express is supported on x64 and EMT64 systems in Windows On Windows (WOW). SQL Server Express is not supported on IA64 systems
// SQLEXPR32.EXE is a smaller package that can be used to install SQL Server Express on 32-bit operating systems only. The larger SQLEXPR.EXE package supports installing onto both 32-bit and 64-bit (WOW install) operating systems. There is no other difference between these packages.
// http://www.microsoft.com/download/en/details.aspx?id=3743

[CustomMessages]
sql2014express_title=SQL Server 2014 Express Service Pack 1      

sql2014express_size=58.2 MB
sql2014express_size_x64=220.1 MB

[Code]
const
  //sql2014express_url = 'http://download.microsoft.com/download/0/1/5/015567C0-E851-4AC6-964F-9BBA9B31D6BC/Express%2064BIT/SQLEXPR_x64_PTB.exe';
	sql2014express_url = 'http://download.microsoft.com/download/1/5/6/156992E6-F7C7-4E55-833D-249BD2348138/ENU/x86/SQLEXPR_x86_ENU.exe';
	//sql2014express_url_x64 = 'http://download.microsoft.com/download/1/5/6/156992E6-F7C7-4E55-833D-249BD2348138/ENU/x64/SQLEXPR_x64_ENU.exe';
  sql2014express_url_x64 = 'http://download.microsoft.com/download/0/1/5/015567C0-E851-4AC6-964F-9BBA9B31D6BC/Express%2064BIT/SQLEXPR_x64_PTB.exe';

procedure sql2014express();
var version: string;
begin
	RegQueryStringValue(HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server\SQLEXPRESS\MSSQLServer\CurrentVersion', 'CurrentVersion', version);
	if (compareversion(version, '12.0') < 0) then begin
		if (not IsIA64()) then
			AddProduct('sql2014express' + GetArchitectureString() + '.exe',
        //'/QS  /IACCEPTSQLSERVERLICENSETERMS /ACTION=Install /FEATURES=SQL,Tools /INSTANCENAME=SQLEXPRESS /SQLSVCACCOUNT=&quot;NT AUTHORITY\Network Service&quot; /SQLSYSADMINACCOUNTS=&quot;builtin\administrators&quot;',				
        '/QS /IACCEPTSQLSERVERLICENSETERMS /HIDECONSOLE  /InstanceName=OMNISERVER /UpdateEnabled=False /Action=Install /Features=SQL /SQLSYSADMINACCOUNTS="BUILTIN\Administrators" /SQLSVCACCOUNT="NT AUTHORITY\NETWORK SERVICE" /SQLSVCSTARTUPTYPE=Automatic /BROWSERSVCSTARTUPTYPE=Automatic ',
				CustomMessage('sql2014express_title'),
				CustomMessage('sql2014express_size' + GetArchitectureString()),
				GetString(sql2014express_url, sql2014express_url_x64, ''),
				false, false);
	end;
end;