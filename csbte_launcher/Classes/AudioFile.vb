Public Class AudioFile
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Int32, ByVal hwndCallback As Int32) As Int32

    Public Sub New(ByVal location As String)
        Me.Filename = location
    End Sub

    Public Sub Play()

        If _filename = Nothing Or Filename.Length <= 4 Then Exit Sub

        Select Case Right(Filename, 3).ToLower
            Case "mp3"
                mciSendString("open """ & _filename & """ type mpegvideo alias audiofile", Nothing, 0, IntPtr.Zero)

                Dim playCommand As String = "play audiofile from 0"

                If _wait = True Then playCommand += " wait"

                mciSendString(playCommand, Nothing, 0, IntPtr.Zero)
            Case "wav"
                mciSendString("open """ & _filename & """ type waveaudio alias audiofile", Nothing, 0, IntPtr.Zero)
                mciSendString("play audiofile from 0", Nothing, 0, IntPtr.Zero)
            Case "mid", "idi"
                mciSendString("stop midi", "", 0, 0)
                mciSendString("close midi", "", 0, 0)
                mciSendString("open sequencer!" & _filename & " alias midi", "", 0, 0)
                mciSendString("play midi", "", 0, 0)
            Case Else
                Throw New Exception("File type not supported.")
                Call Close()
        End Select

        IsPaused = False

    End Sub

    Public Sub Pause()
        mciSendString("pause audiofile", Nothing, 0, IntPtr.Zero)
        IsPaused = True
    End Sub

    Public Sub [Resume]()
        mciSendString("resume audiofile", Nothing, 0, IntPtr.Zero)
        IsPaused = False
    End Sub

    Public Sub [Stop]()
        mciSendString("stop audiofile", Nothing, 0, IntPtr.Zero)
    End Sub

    Public Sub Close()
        mciSendString("close audiofile", Nothing, 0, IntPtr.Zero)
    End Sub

    Private _wait As Boolean = False

    Public Property Wait() As Boolean
        Get
            Return _wait
        End Get
        Set(ByVal value As Boolean)
            _wait = value
        End Set
    End Property

    ReadOnly Property Milleseconds() As Integer
        Get
            Dim buf As String = Space(255)
            mciSendString("set audiofile time format milliseconds", Nothing, 0, IntPtr.Zero)
            mciSendString("status audiofile length", buf, 255, IntPtr.Zero)

            buf = Replace(buf, Chr(0), "") ' Get rid of the nulls, they muck things up

            If buf = "" Then
                Return 0
            Else
                Return CInt(buf)
            End If
        End Get
    End Property

    ReadOnly Property Status() As String
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile mode", buf, 255, IntPtr.Zero)
            buf = Replace(buf, Chr(0), "")  ' Get rid of the nulls, they muck things up
            Return buf
        End Get
    End Property

    ReadOnly Property FileSize() As Integer
        Get
            Try
                Return My.Computer.FileSystem.GetFileInfo(_filename).Length
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    ReadOnly Property Channels() As Integer
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile channels", buf, 255, IntPtr.Zero)

            If IsNumeric(buf) = True Then
                Return CInt(buf)
            Else
                Return -1
            End If
        End Get
    End Property

    ReadOnly Property Debug() As String
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile channels", buf, 255, IntPtr.Zero)

            Return Str(buf)
        End Get
    End Property

    Private _isPaused As Boolean = False

    Public Property IsPaused() As Boolean
        Get
            Return _isPaused
        End Get
        Set(ByVal value As Boolean)
            _isPaused = value
        End Set
    End Property

    Private _filename As String

    Public Property Filename() As String
        Get
            Return _filename
        End Get
        Set(ByVal value As String)

            If My.Computer.FileSystem.FileExists(value) = False Then
                Throw New System.IO.FileNotFoundException
                Exit Property
            End If

            _filename = value
        End Set
    End Property
End Class