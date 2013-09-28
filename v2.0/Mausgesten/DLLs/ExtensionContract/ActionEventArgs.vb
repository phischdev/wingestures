Public Class ActionEventArgs : Inherits EventArgs
    Sub New()
        MyBase.New()
    End Sub

    Sub New(WindowHandle As IntPtr)
        _WindowHandle = WindowHandle
    End Sub

    Dim _WindowHandle As IntPtr
    ReadOnly Property WindowHandle As IntPtr
        Get
            Return _WindowHandle
        End Get
    End Property

End Class
