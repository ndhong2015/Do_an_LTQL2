<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MH_Dang_nhap
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
        Me.Th_Ten_Dang_nhap = New System.Windows.Forms.TextBox()
        Me.Th_Tieu_de = New System.Windows.Forms.Label()
        Me.Th_Mat_khau = New System.Windows.Forms.TextBox()
        Me.Th_Dong_y = New System.Windows.Forms.Button()
        Me.Th_Thong_bao = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Th_Ten_Dang_nhap
        '
        Me.Th_Ten_Dang_nhap.BackColor = System.Drawing.Color.White
        Me.Th_Ten_Dang_nhap.ForeColor = System.Drawing.Color.Gray
        Me.Th_Ten_Dang_nhap.Location = New System.Drawing.Point(90, 77)
        Me.Th_Ten_Dang_nhap.Name = "Th_Ten_Dang_nhap"
        Me.Th_Ten_Dang_nhap.Size = New System.Drawing.Size(188, 29)
        Me.Th_Ten_Dang_nhap.TabIndex = 5
        '
        'Th_Tieu_de
        '
        Me.Th_Tieu_de.AutoSize = True
        Me.Th_Tieu_de.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Th_Tieu_de.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Th_Tieu_de.Location = New System.Drawing.Point(110, 31)
        Me.Th_Tieu_de.Name = "Th_Tieu_de"
        Me.Th_Tieu_de.Size = New System.Drawing.Size(123, 25)
        Me.Th_Tieu_de.TabIndex = 7
        Me.Th_Tieu_de.Text = "Đăng nhập "
        Me.Th_Tieu_de.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Th_Mat_khau
        '
        Me.Th_Mat_khau.BackColor = System.Drawing.Color.White
        Me.Th_Mat_khau.ForeColor = System.Drawing.Color.Gray
        Me.Th_Mat_khau.Location = New System.Drawing.Point(90, 131)
        Me.Th_Mat_khau.Name = "Th_Mat_khau"
        Me.Th_Mat_khau.Size = New System.Drawing.Size(188, 29)
        Me.Th_Mat_khau.TabIndex = 6
        '
        'Th_Dong_y
        '
        Me.Th_Dong_y.BackColor = System.Drawing.Color.Red
        Me.Th_Dong_y.ForeColor = System.Drawing.Color.White
        Me.Th_Dong_y.Location = New System.Drawing.Point(64, 185)
        Me.Th_Dong_y.Name = "Th_Dong_y"
        Me.Th_Dong_y.Size = New System.Drawing.Size(106, 42)
        Me.Th_Dong_y.TabIndex = 8
        Me.Th_Dong_y.Text = "Đồng ý"
        Me.Th_Dong_y.UseVisualStyleBackColor = False
        '
        'Th_Thong_bao
        '
        Me.Th_Thong_bao.AutoSize = True
        Me.Th_Thong_bao.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Th_Thong_bao.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Th_Thong_bao.Location = New System.Drawing.Point(176, 193)
        Me.Th_Thong_bao.Name = "Th_Thong_bao"
        Me.Th_Thong_bao.Size = New System.Drawing.Size(0, 25)
        Me.Th_Thong_bao.TabIndex = 9
        Me.Th_Thong_bao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MH_Dang_nhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(545, 250)
        Me.Controls.Add(Me.Th_Thong_bao)
        Me.Controls.Add(Me.Th_Dong_y)
        Me.Controls.Add(Me.Th_Tieu_de)
        Me.Controls.Add(Me.Th_Mat_khau)
        Me.Controls.Add(Me.Th_Ten_Dang_nhap)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "MH_Dang_nhap"
        Me.Text = "MH_Dang_nhap"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Th_Ten_Dang_nhap As TextBox
    Friend WithEvents Th_Tieu_de As Label
    Friend WithEvents Th_Mat_khau As TextBox
    Friend WithEvents Th_Dong_y As Button
    Friend WithEvents Th_Thong_bao As Label
End Class
