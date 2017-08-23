Option Explicit On
'Option Strict On
'
Imports System
'Imports System.Collections.Generic
'Imports System.Runtime.InteropServices
Imports System.ComponentModel
'Imports System.Data
'Imports System.Drawing
'Imports System.Text
Imports System.Windows.Forms
Imports EyeXFramework
Imports EyeXFramework.Forms
Imports Tobii.EyeX.Client
Imports Tobii.EyeX.Framework
Imports System.Speech
Imports System.Speech.Synthesis
'
Public Class Form1
    '
    ' Test program, some code converted from the Tobii GazeAwareForms sample dotnet program.
    '
    Public speechtts As New SpeechSynthesizer ' make use of speech in this demo
    Dim EyeXHost As New EyeXFramework.Forms.FormsEyeXHost
    Dim LastGazeInteractorID As String = String.Empty ' Save the name of the current gaze interactor
    '
    Const TitleHeight As Integer = 30 ' est. Height of the form title bar
    '
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        speechtts.Speak("Hello " & System.Environment.UserName) ' Say Hello to the user
        '
        Try ' setup the Gaze Interactor behaviors
            EyeXHost.Connect(BehaviorMap1)
            BehaviorMap1.Add(Panel1, New GazeAwareBehavior(AddressOf OnGaze) With {.DelayMilliseconds = 500})
            BehaviorMap1.Add(Panel2, New GazeAwareBehavior(AddressOf OnGaze) With {.DelayMilliseconds = 500})
            BehaviorMap1.Add(Panel3, New GazeAwareBehavior(AddressOf OnGaze) With {.DelayMilliseconds = 500})
            BehaviorMap1.Add(Panel4, New GazeAwareBehavior(AddressOf OnGaze) With {.DelayMilliseconds = 500})
            BehaviorMap1.Add(Panel5, New GazeAwareBehavior(AddressOf OnGaze)) ' no delay
            '
            BehaviorMap1.Add(Button1, New GazeAwareBehavior(AddressOf OnGaze) With {.DelayMilliseconds = 2000})
            BehaviorMap1.Add(Button2, New GazeAwareBehavior(AddressOf OnGaze) With {.DelayMilliseconds = 2000})
            BehaviorMap1.Add(Button3, New GazeAwareBehavior(AddressOf OnGaze) With {.DelayMilliseconds = 2000})
            '
            BehaviorMap1.Add(PictureBox1, New GazeAwareBehavior(AddressOf OnGaze) With {.DelayMilliseconds = 500})
            '
            BehaviorMap1.Add(HScrollBar1, New GazeAwareBehavior(AddressOf OnGaze) With {.DelayMilliseconds = 500})
            BehaviorMap1.Add(TrackBar1, New GazeAwareBehavior(AddressOf OnGaze) With {.DelayMilliseconds = 500})
            '
            EyeXHost.Start() ' Start using the EyeTracker
            '
        Catch ex As Exception
            Console.WriteLine("Load " & ex.Message)
        End Try
        '
    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '  Add your own exit code
        '
    End Sub

    Public Sub OnGaze(sender As Object, e As GazeAwareEventArgs)
        ' On Gaze code to handle Interactor items looked at
        '
        ' three buttons on screen
        Dim MyButton = TryCast(sender, Button)
        '
        If MyButton IsNot Nothing Then
            Cursor.Position = New Point(Bounds.Left + MyButton.Location.X + (MyButton.Width / 2), Bounds.Top + TitleHeight + MyButton.Location.Y + (MyButton.Height / 2))
            Select Case sender.name
                Case "Button1"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        MyButton.Text = If((e.HasGaze), "BYE-BYE", "EXIT")
                        Application.DoEvents()
                        '
                        MyButton.PerformClick()
                    End If
                    '
                Case "Button2"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        MyButton.PerformClick()
                    End If

                Case "Button3"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        MyButton.PerformClick()
                    End If
                    '
                Case Else
                    '
                    ' test if needed
            End Select
            '
        End If
        '
        '-------------------------------------------------------------------------------------
        '
        Dim MyPicture = TryCast(sender, PictureBox)
        '
        If MyPicture IsNot Nothing Then
            MyPicture.BorderStyle = If((e.HasGaze), BorderStyle.Fixed3D, BorderStyle.None)
            Cursor.Position = New Point(Bounds.Left + MyPicture.Location.X + MyPicture.Width / 2, Bounds.Top + TitleHeight + MyPicture.Location.Y + MyPicture.Height / 2)
            '
            Select Case sender.name
                Case "PictureBox1"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        Application.DoEvents()
                        speechtts.Speak("Hello Mickey ") ' speak the button name
                    End If
                    '
                Case Else
                    '
            End Select
        End If
        '
        '-------------------------------------------------------------------------------------------
        '
        Dim MyScrollbar = TryCast(sender, ScrollBar)
        '
        If MyScrollbar IsNot Nothing Then
            Cursor.Position = New Point(Bounds.Left + MyScrollbar.Location.X + MyScrollbar.Width / 2, Bounds.Top + TitleHeight + MyScrollbar.Location.Y + MyScrollbar.Height / 2)
            '
            Select Case sender.name
                Case "HScrollBar1"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        Application.DoEvents()
                        speechtts.Speak("Scroll bar selected") ' speak the button name
                    End If
                    '
                Case Else
                    '
            End Select
        End If
        '
        '-------------------------------------------------------------------------------------------
        '
        Dim MyTrackbar = TryCast(sender, TrackBar)
        '
        If MyTrackbar IsNot Nothing Then
            Cursor.Position = New Point(Bounds.Left + MyTrackbar.Location.X + MyTrackbar.Width / 2, Bounds.Top + TitleHeight + MyTrackbar.Location.Y + MyTrackbar.Height / 2)
            '
            Select Case sender.name
                Case "TrackBar1"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        Application.DoEvents()
                        speechtts.Speak("Track bar selected") ' speak the button name
                    End If
                    '
                Case Else
                    '
            End Select
        End If
        '
        '----------------------------------------------------------------------
        '
        Dim MyPanel = TryCast(sender, Panel)
        '
        If MyPanel IsNot Nothing Then
            MyPanel.BorderStyle = If((e.HasGaze), BorderStyle.Fixed3D, BorderStyle.None)
            Cursor.Position = New Point(Bounds.Left + MyPanel.Location.X + MyPanel.Width / 2, Bounds.Top + TitleHeight + MyPanel.Location.Y + MyPanel.Height / 2)
            '
            Select Case sender.name
                Case "Panel1"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        speechtts.Speak("Are you looking at me? ") ' speak the button name
                    End If
                    '
                Case "Panel2"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        speechtts.Speak("You are looking at panel 2! ") ' speak the button name
                    End If
                    '
                Case "Panel3"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        speechtts.Speak("My what big eyes you have! ") ' speak the button name
                    End If
                    '
                Case "Panel4"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        speechtts.Speak("You are looking at Panel 4 ") ' speak the button name
                    End If
                    '
                Case "Panel5"
                    If sender.name = LastGazeInteractorID Then
                        ' do nothing
                    Else
                        speechtts.Speak("You are looking at Panel 5 ") ' speak the button name
                    End If
                    '
                Case Else
                    ' test if needed
            End Select
            '
            '
        End If
        ' save last interactor looked at
        LastGazeInteractorID = sender.name
        ToolStripStatusLabel3.Text = sender.name
        '
        Application.DoEvents()
        '
    End Sub
    '
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '
        speechtts.Speak("sorry to see you leave!, Goodbye ") ' speak the button name
        '
        Me.Close()
        '
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '
        sender.text = "Clicked"
        '
        speechtts.Speak("I am Button 2 ") ' speak the button name
        '
    End Sub
    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        '
        sender.text = "Button2"
        '
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '
        sender.text = "Clicked"
        '
        speechtts.Speak("I am Button 3 ") ' speak the button name
        '
    End Sub
    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        '
        sender.text = "Button3"
        '
    End Sub
    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        'ToolStripStatusLabel1.Text = Cursor.Position.X.ToString
        'ToolStripStatusLabel2.Text = Cursor.Position.Y.ToString
    End Sub

    '
End Class



Public Class GazeAwareBehavior
    Implements IEyeXBehavior

    Public Sub New()
    End Sub
    Public Sub New(eventHandler As EventHandler(Of GazeAwareEventArgs))
        AddHandler GazeAware, eventHandler
    End Sub

    ''' <summary>
    ''' The event raised when the gaze moves in or out if the interactor.
    ''' </summary>
    Public Event GazeAware As EventHandler(Of GazeAwareEventArgs)
    Public ReadOnly Property BehaviorType As BehaviorType Implements IEyeXBehavior.BehaviorType
        Get
            Return BehaviorType.GazeAware
        End Get
    End Property
    Public Property DelayMilliseconds() As Integer
        Get
            Return m_DelayMilliseconds
        End Get
        Set
            m_DelayMilliseconds = Value
        End Set
    End Property
    Private m_DelayMilliseconds As Integer
    Public Sub AssignBehavior(interactor As Interactor) Implements IEyeXBehavior.AssignBehavior
        '
        Using behavior = interactor.CreateBehavior(BehaviorType.GazeAware)
            If DelayMilliseconds > 0 Then
                Dim parameters = New GazeAwareParams() With {
                                .GazeAwareMode = GazeAwareMode.Delayed,
                                .DelayTime = DelayMilliseconds
                }
                behavior.SetGazeAwareParams(parameters)
            Else
                Dim parameters = New GazeAwareParams() With {
                                .GazeAwareMode = GazeAwareMode.Normal
                }
                behavior.SetGazeAwareParams(parameters)
            End If
        End Using
    End Sub

    Public Sub HandleEvent(sender As Object, behaviors As IEnumerable(Of Behavior)) Implements IEyeXBehavior.HandleEvent
        For Each behavior As Object In behaviors.Where(Function(b) b.BehaviorType = BehaviorType.GazeAware)
            Dim parameters As GazeAwareEventParams
            If behavior.TryGetGazeAwareEventParams(parameters) Then
                RaiseEvent GazeAware(sender, New GazeAwareEventArgs(parameters.HasGaze <> EyeXBoolean.[False]))
            End If
        Next
    End Sub
End Class
Public NotInheritable Class GazeAwareEventArgs
    Inherits EventArgs
    ''' <summary>
    ''' Initializes a new instance of the <see cref="GazeAwareEventArgs"/> class.
    ''' </summary>
    ''' <param name="hasGaze__1">True if the gaze point falls within the bounds of the interactor.</param>
    Public Sub New(hasGaze__1 As Boolean)
        HasGaze = hasGaze__1
    End Sub

    ''' <summary>
    ''' Gets a value indicating whether the gaze point falls within the bounds of the interactor.
    ''' </summary>
    Public Property HasGaze() As Boolean
        Get
            Return m_HasGaze
        End Get
        Private Set
            m_HasGaze = Value
        End Set
    End Property
    Private m_HasGaze As Boolean
End Class