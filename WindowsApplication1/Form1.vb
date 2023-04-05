Public Class AWT计时器
    Dim xx As Integer, yy As Integer, aa As Boolean '用于窗体移动
    Dim H As String, M As String, S As String '用于储存时分秒
    Dim N As String '为Timer3、Timer4两个计时器提供次数/周期次数记录
    Public NN As String = 0  '为Listbox提供计数次数，并定义为全局变量
    Dim VOL As Integer '定义音量变量
    Public F2Rings As Integer = 0, F2TBVL As Integer = 75  '声明全局变量F2Rings和F2TBVL（Form2 TrackBar's Value），令Form2的ComboBox1和TrackBar1中的数值传递到AWT计时器类中

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        End
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "×"
        Me.BackColor = Color.LightSkyBlue
        Label1.ForeColor = Color.White
        Label2.Text = "Skysail TC"
        Label2.ForeColor = Color.White
        TextBox1.Text = 0
        Label3.Text = "·"
        Label4.Text = "·"
        TextBox3.Text = 0
        TextBox2.Text = 0
        Button1.Text = "结束"
        Button2.Text = "开始"
        Button1.Enabled = False
        Button3.Enabled = False
        Button3.Text = "计次"
        Button5.Enabled = True
        Button5.Text = "清零"
        Button4.Enabled = True
        Button4.Text = "清除计次"
        Button6.Enabled = True
        Button6.Text = "关闭计次窗"
        Label7.Text = "↑"
        Label8.Text = "↑"
        Label9.Text = "↑"
        Label10.Text = "↓"
        Label11.Text = "↓"
        Label12.Text = "↓"
        Timer1.Enabled = False '先关闭计时器以节约内存空间
        Timer1.Interval = 1000 '设置时间间隔
        Timer2.Enabled = False
        Timer2.Interval = 1000
        Timer3.Enabled = False
        Timer3.Interval = 10
        Timer4.Enabled = False
        Timer4.Interval = 10
        Me.AxWindowsMediaPlayer1.Visible = False   '令Windows Media Player控件不可见
        Label13.Text = "时"
        Label14.Text = "分"
        Label15.Text = "秒"
        Label16.Text = "⚙ 附加选项"
        RadioButton1.Text = "倒计时"
        RadioButton1.ForeColor = Color.WhiteSmoke
        RadioButton2.Text = "秒表"
        RadioButton2.ForeColor = Color.WhiteSmoke
        ProgressBar1.Value = 0
        CheckBox1.Text = "进度条"
        CheckBox1.ForeColor = Color.WhiteSmoke
        ProgressBar1.Visible = False
        ProgressBar1.Maximum = 100
        N = 0
        Me.AxWindowsMediaPlayer1.settings.volume = 75
        RadioButton1.Select()
        ListBox1.Visible = False
        ListBox1.SelectionMode = SelectionMode.One
        GroupBox1.Text = "计次窗功能"
        GroupBox1.Visible = False
        CheckBox2.Text = "计次窗选项"
        ToolTip1.AutoPopDelay = 5000 '显示停留5秒
        ToolTip1.InitialDelay = 1000 '1秒后显示
        ToolTip1.ReshowDelay = 1000 '从一个控件移到另一个控件1秒后显示
        ToolTip1.ShowAlways = True '在窗口不活动时也显示
        '完成UI/UX的初始化设置
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        Label1.ForeColor = Color.LightSkyBlue
    End Sub

    Private Sub Label1_MouseHover(sender As Object, e As EventArgs) Handles Label1.MouseHover
        ToolTip1.SetToolTip(Label1, "关闭程序")
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        Label1.BackColor = Color.Red
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        Label1.BackColor = Color.LightSkyBlue : Label1.ForeColor = Color.White
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        xx = e.X '定义变量xx为鼠标指针的横坐标
        yy = e.Y '定义变量yy为鼠标指针的纵坐标
        aa = True '设置布朗值aa为True
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If aa = True Then
            Me.Left = Me.Left + (e.X - xx)
            Me.Top = Me.Top + (e.Y - yy)
        End If '在鼠标移动的过程中，如果横坐标或者纵坐标发生变化，那么窗体的顶部或左部则会向后面的鼠标指针坐标的方向移动后面的鼠标指针坐标与初始鼠标指针坐标差值个单位距离
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        aa = False '放开鼠标，则设置aa为False，窗体不随鼠标指针的移动而移动
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        TextBox1.Text = TextBox1.Text + 1
        If TextBox1.Text >= 99 Then TextBox1.Text = "0" '由于“时”的定义域为[0,+∞)，考虑到美观和稳定问题，最大值定为99小时
    End Sub
    Private Sub Label7_MouseLeave(sender As Object, e As EventArgs) Handles Label7.MouseLeave
        Label7.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        TextBox2.Text = TextBox2.Text + 1
        If TextBox2.Text >= 60 Then TextBox2.Text = "0" '由于进位机制，当“分”大于等于60时，变为0
    End Sub

    Private Sub Label8_MouseLeave(sender As Object, e As EventArgs) Handles Label8.MouseLeave
        Label8.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Label8_MouseMove(sender As Object, e As MouseEventArgs) Handles Label8.MouseMove
        Label8.BackColor = Color.LightSeaGreen
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        TextBox3.Text = TextBox3.Text + 1
        If TextBox3.Text >= 60 Then TextBox3.Text = "0" '同理，如“分”一栏
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        TextBox1.Text = TextBox1.Text - 1
        If TextBox1.Text < 0 Then TextBox1.Text = 99 ' 如果“时”一栏的数值小于0，那么由于退位，变成99
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        TextBox2.Text = TextBox2.Text - 1
        If TextBox2.Text < 0 Then TextBox2.Text = 59 '同理，如“时”一栏
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        TextBox3.Text = TextBox3.Text - 1
        If TextBox3.Text <= 0 Then TextBox3.Text = 59
    End Sub

    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs) Handles Label2.MouseDown
        xx = e.X
        yy = e.Y
        aa = True
    End Sub

    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove
        If aa = True Then
            Me.Left = Me.Left + (e.X - xx)
            Me.Top = Me.Top + (e.Y - yy)
        End If
    End Sub

    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs) Handles Label2.MouseUp
        aa = False '上述三段代码用于处理“Label1”在被当作如窗体般拖动时，窗体的移动问题，效果同前面的“窗体移动”代码
    End Sub

    Private Sub Label7_MouseMove(sender As Object, e As MouseEventArgs) Handles Label7.MouseMove
        Label7.BackColor = Color.LightSeaGreen
    End Sub

    Private Sub Label9_MouseLeave(sender As Object, e As EventArgs) Handles Label9.MouseLeave
        Label9.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Label9_MouseMove(sender As Object, e As MouseEventArgs) Handles Label9.MouseMove
        Label9.BackColor = Color.LightSeaGreen
    End Sub

    Private Sub Label10_MouseLeave(sender As Object, e As EventArgs) Handles Label10.MouseLeave
        Label10.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Label10_MouseMove(sender As Object, e As MouseEventArgs) Handles Label10.MouseMove
        Label10.BackColor = Color.LightSeaGreen
    End Sub

    Private Sub Label11_MouseLeave(sender As Object, e As EventArgs) Handles Label11.MouseLeave
        Label11.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Label11_MouseMove(sender As Object, e As MouseEventArgs) Handles Label11.MouseMove
        Label11.BackColor = Color.LightSeaGreen
    End Sub

    Private Sub Label12_MouseLeave(sender As Object, e As EventArgs) Handles Label12.MouseLeave
        Label12.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Label12_MouseMove(sender As Object, e As MouseEventArgs) Handles Label12.MouseMove
        Label12.BackColor = Color.LightSeaGreen '用以处理“箭头”被点击时的UI变化效果
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox3.Text = TextBox3.Text - 1

        If (CheckBox1.Checked = True) And ((H * 3600 + M * 60 + S) > 0) Then
            ProgressBar1.Value = 100 - ((TextBox1.Text * 3600 + TextBox2.Text * 60 + TextBox3.Text) / (H * 3600 + M * 60 + S)) * 100
        End If

        If (TextBox1.Text * 3600 + TextBox2.Text * 60 + TextBox3.Text = 0) And (CheckBox1.Checked = True) Then
            ProgressBar1.Value = 100
        End If

        If (TextBox3.Text < 0) And (TextBox2.Text > 0) Then
            TextBox3.Text = 59
            TextBox2.Text = TextBox2.Text - 1 '当“秒”小于0，且“分”不为0时，由于退位机制，“秒”变59而“分”减少1
        End If

        If (TextBox3.Text < 0) And (TextBox2.Text = 0) And (TextBox1.Text > 0) Then
            TextBox1.Text = TextBox1.Text - 1
            TextBox2.Text = 59
            TextBox3.Text = 59 '如果“秒”小于0，但是“分”为0，而“时”大于0，那么由于退位，“秒”和“分”全部变成59
        End If

        If (TextBox3.Text <= 0) And (TextBox2.Text = 0) And (TextBox1.Text = 0) Then
            TextBox3.Text = 0
            Timer1.Enabled = False
            Button1.Enabled = False : Button3.Enabled = False
            Label7.Visible = True : Label8.Visible = True : Label9.Visible = True : Label10.Visible = True : Label11.Visible = True : Label12.Visible = True
            Select Case F2Rings
                Case Is = 0
                    Me.AxWindowsMediaPlayer1.URL = Application.StartupPath & "\rings\Ring0.wav"
                Case Is = 1
                    Me.AxWindowsMediaPlayer1.URL = Application.StartupPath & "\rings\Ring1.wav"
                Case Is = 2
                    Me.AxWindowsMediaPlayer1.URL = Application.StartupPath & "\rings\Ring2.wav"
                Case Is = 3
                    Me.AxWindowsMediaPlayer1.URL = Application.StartupPath & "\rings\Ring3.wav"
                Case Is = 4
                    Me.AxWindowsMediaPlayer1.URL = Application.StartupPath & "\rings\Ring4.wav"
                Case Is = 5
                    Me.AxWindowsMediaPlayer1.URL = Application.StartupPath & "\rings\Ring5.wav"
                Case Else
                    Me.AxWindowsMediaPlayer1.URL = Application.StartupPath & "\rings\Ring0.wav"
            End Select '根据附加选项里的“选曲”进行调节

            TextBox1.Enabled = True : TextBox2.Enabled = True : TextBox3.Enabled = True
            CheckBox1.Enabled = True : Button2.Enabled = True : Button4.Enabled = True : Button5.Enabled = True : Button6.Enabled = True
            If MsgBox("计时已结束", vbOKOnly, "提示") = MsgBoxResult.Ok Then Me.AxWindowsMediaPlayer1.close() : ProgressBar1.Visible = False
        End If '此时情况为：已经完成计时，因为时分秒已经归0了，在调节箭头全部恢复、开始计时按钮恢复可用的同时，播放音乐，并弹出提示框
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        H = TextBox1.Text : M = TextBox2.Text : S = TextBox3.Text
        Me.AxWindowsMediaPlayer1.settings.volume = F2TBVL
        ProgressBar1.Value = 0
        If RadioButton1.Checked = True Then
            Label1.Focus() 'UI效果，防止某个Textbox存在焦点而开始运行时导致的闪烁
            Timer1.Enabled = True
            Button1.Enabled = True : Button2.Enabled = False : Button3.Enabled = True : Button4.Enabled = False : Button5.Enabled = False : Button6.Enabled = False
            Label7.Visible = False : Label8.Visible = False : Label9.Visible = False : Label10.Visible = False : Label11.Visible = False : Label12.Visible = False
            TextBox1.Enabled = False : TextBox2.Enabled = False : TextBox3.Enabled = False '在Radiobutton1被选中时，激活Timer1，并且设置其他控件的变化属性
        Else
            Label1.Focus()
            Timer2.Enabled = True
            Button1.Enabled = True : Button2.Enabled = False : Button3.Enabled = True : Button4.Enabled = False : Button5.Enabled = False : Button6.Enabled = False
            Label7.Visible = False : Label8.Visible = False : Label9.Visible = False : Label10.Visible = False : Label11.Visible = False : Label12.Visible = False
            TextBox1.Enabled = False : TextBox2.Enabled = False : TextBox3.Enabled = False '暂时隐藏箭头和调整按钮,激活Timer2，并设置其他控件属性
        End If

        If (CheckBox1.Checked = True) And (RadioButton1.Checked = True) Then
            ProgressBar1.Visible = True
        Else
            ProgressBar1.Visible = False
        End If
        CheckBox1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Focus()
        Timer1.Enabled = False : Timer2.Enabled = False
        Button1.Enabled = False : Button3.Enabled = False : Button4.Enabled = True : Button5.Enabled = True : Button6.Enabled = True
        Button2.Enabled = True
        Label7.Visible = True : Label8.Visible = True : Label9.Visible = True : Label10.Visible = True : Label11.Visible = True : Label12.Visible = True
        TextBox1.Enabled = True : TextBox2.Enabled = True : TextBox3.Enabled = True '恢复箭头、按钮等
        If RadioButton1.Checked = True Then CheckBox1.Enabled = True
        ProgressBar1.Visible = False
    End Sub

    Private Sub TextBox1_MouseHover(sender As Object, e As EventArgs) Handles TextBox1.MouseHover
        ToolTip1.SetToolTip(TextBox1, "选中后通过按钮进行调节，也可以通过鼠标滚轮进行调节") '提示内容
    End Sub

    Private Sub TextBox1_MouseWheel(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseWheel
        If (e.Delta >= 1) Then TextBox1.Text = TextBox1.Text + 1 : If TextBox1.Text >= 100 Then TextBox1.Text = 0
        If (e.Delta <= 1) Then TextBox1.Text = TextBox1.Text - 1 : If TextBox1.Text <= 0 Then TextBox1.Text = 99 '如果鼠标滚轮有变化，那么Textbox依据变化来变化时间数值
    End Sub

    Private Sub TextBox2_MouseHover(sender As Object, e As EventArgs) Handles TextBox2.MouseHover
        ToolTip1.SetToolTip(TextBox2, "选中后通过按钮进行调节，也可以通过鼠标滚轮进行调节")
    End Sub

    Private Sub TextBox2_MouseWheel(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseWheel
        If (e.Delta >= 1) Then TextBox2.Text = TextBox2.Text + 1 : If TextBox2.Text >= 60 Then TextBox2.Text = 0
        If (e.Delta <= 1) Then TextBox2.Text = TextBox2.Text - 1 : If TextBox2.Text <= 0 Then TextBox2.Text = 59
    End Sub

    Private Sub TextBox3_MouseHover(sender As Object, e As EventArgs) Handles TextBox3.MouseHover
        ToolTip1.SetToolTip(TextBox3, "选中后通过按钮进行调节，也可以通过鼠标滚轮进行调节")
    End Sub

    Private Sub TextBox3_MouseWheel(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseWheel
        If (e.Delta >= 1) Then TextBox3.Text = TextBox3.Text + 1 : If TextBox3.Text >= 60 Then TextBox3.Text = 0
        If (e.Delta <= 1) Then TextBox3.Text = TextBox3.Text - 1 : If TextBox3.Text <= 0 Then TextBox3.Text = 59
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        TextBox3.Text = TextBox3.Text + 1
        If (TextBox3.Text >= 60) And (TextBox2.Text < 59) Then
            TextBox3.Text = 0
            TextBox2.Text = TextBox2.Text + 1
        End If

        If (TextBox3.Text >= 60) And (TextBox2.Text >= 59) Then
            TextBox3.Text = 0 : TextBox2.Text = 0
            TextBox1.Text = TextBox1.Text + 1
        End If

        If (TextBox1.Text >= 100) Then
            TextBox1.Text = 0
            Timer1.Enabled = False
            Timer2.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = True
            Label7.Visible = True
            Label8.Visible = True
            Label9.Visible = True
            Label10.Visible = True
            Label11.Visible = True
            Label12.Visible = True '恢复箭头、按钮等
            TextBox1.Enabled = True : TextBox2.Enabled = True : TextBox3.Enabled = True
            MsgBox("超出计时范围", 0, "警告")
        End If
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        CheckBox1.Enabled = False
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        CheckBox1.Enabled = True '通过选择按钮改变复选框的可用性
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NN = NN + 1
        ListBox1.Visible = True
        ListBox1.Items.Insert(0, NN & "." & " " & TextBox1.Text & ":" & TextBox2.Text & ":" & TextBox3.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListBox1.Items.Clear()
        NN = 0
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = 0 : TextBox2.Text = 0 : TextBox3.Text = 0
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ListBox1.Visible = False
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        Select Case CheckBox2.Checked
            Case Is = True
                GroupBox1.Show()
            Case Else
                GroupBox1.Hide()
        End Select
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Dim OpenF2 As New Form2()
        Form2.Show()
        Form2.Focus()
    End Sub

    Private Sub Label16_MouseDown(sender As Object, e As MouseEventArgs) Handles Label16.MouseDown
        Label16.ForeColor = Color.Black
    End Sub

    Private Sub Label16_MouseLeave(sender As Object, e As EventArgs) Handles Label16.MouseLeave
        Label16.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Label16_MouseMove(sender As Object, e As MouseEventArgs) Handles Label16.MouseMove
        Label16.BackColor = Color.Violet
    End Sub

    Private Sub label16_MouseUp(sender As Object, e As MouseEventArgs) Handles Label16.MouseUp
        Label16.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        ToolTip1.SetToolTip(Button1, "停止计时，保留最后一次的时间")
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        ToolTip1.SetToolTip(Button3, "对当前时间进行记录")
    End Sub

    Private Sub Button5_MouseHover(sender As Object, e As EventArgs) Handles Button5.MouseHover
        ToolTip1.SetToolTip(Button5, "清零时间")
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        ToolTip1.SetToolTip(Button2, "开始计时")
    End Sub

    Private Sub CheckBox1_MouseHover(sender As Object, e As EventArgs) Handles CheckBox1.MouseHover
        ToolTip1.SetToolTip(CheckBox1, "选中以在倒计时模式时显示进度条")
    End Sub

    Private Sub CheckBox2_MouseHover(sender As Object, e As EventArgs) Handles CheckBox2.MouseHover
        ToolTip1.SetToolTip(CheckBox2, "选中以加载计次窗选项")
    End Sub
End Class
