<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InsertTimeDate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.CheckBox()
        Me.grpInclude = New System.Windows.Forms.GroupBox()
        Me.chk2DigitYear = New System.Windows.Forms.CheckBox()
        Me.chkNumMonth = New System.Windows.Forms.CheckBox()
        Me.chk24hour = New System.Windows.Forms.CheckBox()
        Me.chkYear = New System.Windows.Forms.CheckBox()
        Me.chkDay = New System.Windows.Forms.CheckBox()
        Me.chkMonth = New System.Windows.Forms.CheckBox()
        Me.chkTimezone = New System.Windows.Forms.CheckBox()
        Me.chkSec = New System.Windows.Forms.CheckBox()
        Me.chkMins = New System.Windows.Forms.CheckBox()
        Me.chkHours = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSample = New System.Windows.Forms.Label()
        Me.grpInclude.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(241, 149)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(63, 25)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "Insert"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(310, 149)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(63, 25)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.AutoSize = True
        Me.cmdSave.Location = New System.Drawing.Point(110, 154)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(125, 17)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.Text = "Save for this Session"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'grpInclude
        '
        Me.grpInclude.Controls.Add(Me.chk2DigitYear)
        Me.grpInclude.Controls.Add(Me.chkNumMonth)
        Me.grpInclude.Controls.Add(Me.chk24hour)
        Me.grpInclude.Controls.Add(Me.chkYear)
        Me.grpInclude.Controls.Add(Me.chkDay)
        Me.grpInclude.Controls.Add(Me.chkMonth)
        Me.grpInclude.Controls.Add(Me.chkTimezone)
        Me.grpInclude.Controls.Add(Me.chkSec)
        Me.grpInclude.Controls.Add(Me.chkMins)
        Me.grpInclude.Controls.Add(Me.chkHours)
        Me.grpInclude.Location = New System.Drawing.Point(17, 8)
        Me.grpInclude.Name = "grpInclude"
        Me.grpInclude.Size = New System.Drawing.Size(218, 134)
        Me.grpInclude.TabIndex = 3
        Me.grpInclude.TabStop = False
        Me.grpInclude.Text = "Include:"
        '
        'chk2DigitYear
        '
        Me.chk2DigitYear.AutoSize = True
        Me.chk2DigitYear.Location = New System.Drawing.Point(122, 111)
        Me.chk2DigitYear.Name = "chk2DigitYear"
        Me.chk2DigitYear.Size = New System.Drawing.Size(81, 17)
        Me.chk2DigitYear.TabIndex = 9
        Me.chk2DigitYear.Text = "2-Digit Year"
        Me.chk2DigitYear.UseVisualStyleBackColor = True
        '
        'chkNumMonth
        '
        Me.chkNumMonth.AutoSize = True
        Me.chkNumMonth.Location = New System.Drawing.Point(122, 89)
        Me.chkNumMonth.Name = "chkNumMonth"
        Me.chkNumMonth.Size = New System.Drawing.Size(84, 17)
        Me.chkNumMonth.TabIndex = 8
        Me.chkNumMonth.Text = "Num. Month"
        Me.chkNumMonth.UseVisualStyleBackColor = True
        '
        'chk24hour
        '
        Me.chk24hour.AutoSize = True
        Me.chk24hour.Location = New System.Drawing.Point(12, 89)
        Me.chk24hour.Name = "chk24hour"
        Me.chk24hour.Size = New System.Drawing.Size(91, 17)
        Me.chk24hour.TabIndex = 7
        Me.chk24hour.Text = "24-hour clock"
        Me.chk24hour.UseVisualStyleBackColor = True
        '
        'chkYear
        '
        Me.chkYear.AutoSize = True
        Me.chkYear.Location = New System.Drawing.Point(122, 66)
        Me.chkYear.Name = "chkYear"
        Me.chkYear.Size = New System.Drawing.Size(48, 17)
        Me.chkYear.TabIndex = 6
        Me.chkYear.Text = "Year"
        Me.chkYear.UseVisualStyleBackColor = True
        '
        'chkDay
        '
        Me.chkDay.AutoSize = True
        Me.chkDay.Location = New System.Drawing.Point(122, 43)
        Me.chkDay.Name = "chkDay"
        Me.chkDay.Size = New System.Drawing.Size(45, 17)
        Me.chkDay.TabIndex = 5
        Me.chkDay.Text = "Day"
        Me.chkDay.UseVisualStyleBackColor = True
        '
        'chkMonth
        '
        Me.chkMonth.AutoSize = True
        Me.chkMonth.Location = New System.Drawing.Point(122, 20)
        Me.chkMonth.Name = "chkMonth"
        Me.chkMonth.Size = New System.Drawing.Size(56, 17)
        Me.chkMonth.TabIndex = 4
        Me.chkMonth.Text = "Month"
        Me.chkMonth.UseVisualStyleBackColor = True
        '
        'chkTimezone
        '
        Me.chkTimezone.AutoSize = True
        Me.chkTimezone.Location = New System.Drawing.Point(12, 112)
        Me.chkTimezone.Name = "chkTimezone"
        Me.chkTimezone.Size = New System.Drawing.Size(80, 17)
        Me.chkTimezone.TabIndex = 3
        Me.chkTimezone.Text = "Time Offset"
        Me.chkTimezone.UseVisualStyleBackColor = True
        '
        'chkSec
        '
        Me.chkSec.AutoSize = True
        Me.chkSec.Location = New System.Drawing.Point(12, 66)
        Me.chkSec.Name = "chkSec"
        Me.chkSec.Size = New System.Drawing.Size(68, 17)
        Me.chkSec.TabIndex = 2
        Me.chkSec.Text = "Seconds"
        Me.chkSec.UseVisualStyleBackColor = True
        '
        'chkMins
        '
        Me.chkMins.AutoSize = True
        Me.chkMins.Location = New System.Drawing.Point(12, 43)
        Me.chkMins.Name = "chkMins"
        Me.chkMins.Size = New System.Drawing.Size(63, 17)
        Me.chkMins.TabIndex = 1
        Me.chkMins.Text = "Minutes"
        Me.chkMins.UseVisualStyleBackColor = True
        '
        'chkHours
        '
        Me.chkHours.AutoSize = True
        Me.chkHours.Location = New System.Drawing.Point(12, 20)
        Me.chkHours.Name = "chkHours"
        Me.chkHours.Size = New System.Drawing.Size(54, 17)
        Me.chkHours.TabIndex = 0
        Me.chkHours.Text = "Hours"
        Me.chkHours.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSample)
        Me.GroupBox1.Location = New System.Drawing.Point(247, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(125, 60)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sample"
        '
        'lblSample
        '
        Me.lblSample.AutoSize = True
        Me.lblSample.Location = New System.Drawing.Point(41, 24)
        Me.lblSample.Name = "lblSample"
        Me.lblSample.Size = New System.Drawing.Size(42, 13)
        Me.lblSample.TabIndex = 0
        Me.lblSample.Text = "Sample"
        '
        'InsertTimeDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 182)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpInclude)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InsertTimeDate"
        Me.Text = "Insert Time & Date"
        Me.grpInclude.ResumeLayout(False)
        Me.grpInclude.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.CheckBox
    Friend WithEvents grpInclude As System.Windows.Forms.GroupBox
    Friend WithEvents chkSec As System.Windows.Forms.CheckBox
    Friend WithEvents chkMins As System.Windows.Forms.CheckBox
    Friend WithEvents chkHours As System.Windows.Forms.CheckBox
    Friend WithEvents chkTimezone As System.Windows.Forms.CheckBox
    Friend WithEvents chk24hour As System.Windows.Forms.CheckBox
    Friend WithEvents chkYear As System.Windows.Forms.CheckBox
    Friend WithEvents chkDay As System.Windows.Forms.CheckBox
    Friend WithEvents chkMonth As System.Windows.Forms.CheckBox
    Friend WithEvents chkNumMonth As System.Windows.Forms.CheckBox
    Friend WithEvents chk2DigitYear As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSample As System.Windows.Forms.Label
End Class
