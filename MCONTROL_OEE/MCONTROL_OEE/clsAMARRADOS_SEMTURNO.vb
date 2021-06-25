Public Class clsAMARRADOS_SEMTURNO

    Public intUSERID As Integer
    Public strCENTRO_TRABALHO As String
    Public strORDEM As String
    Public strNUMHU As String
    Public strLOTE As String
    Public dtimeRECEBIDO As DateTime
    Public Sub New(ByVal _intUSERID As Integer,
                   ByVal _strCENTRO_TRABALHO As String,
                   ByVal _strORDEM As String,
                   ByVal _strNUMHU As String,
                   ByVal _strLOTE As String,
                   ByVal _dtimeRECEBIDO As DateTime)

        Me.intUSERID = _intUSERID
        Me.strCENTRO_TRABALHO = _strCENTRO_TRABALHO
        Me.strORDEM = _strORDEM
        Me.strNUMHU = _strNUMHU
        Me.strLOTE = _strLOTE
        Me.dtimeRECEBIDO = _dtimeRECEBIDO

    End Sub

End Class
