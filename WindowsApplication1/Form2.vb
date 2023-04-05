Partial Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "附加选项"
        TrackBar1.Maximum = 100 : TrackBar1.Minimum = 0
        Me.TrackBar1.Value = AWT计时器.F2TBVL
        ComboBox1.Items.Add("1. 默认") : ComboBox1.Items.Add("2. 心潮澎湃") : ComboBox1.Items.Add("3. 空灵") : ComboBox1.Items.Add("4. 草原") : ComboBox1.Items.Add("5. 三角铁") : ComboBox1.Items.Add("6. 欢沁")
        ComboBox1.SelectedIndex = AWT计时器.F2Rings
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AWT计时器.AxWindowsMediaPlayer1.settings.volume = TrackBar1.Value
        AWT计时器.F2Rings = Me.ComboBox1.SelectedIndex '传递ComboBox1的数值到AWT计时器类中
        AWT计时器.F2TBVL = Me.TrackBar1.Value '同上
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class

