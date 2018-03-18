<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MH_Dat_San_pham
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Trinh_duyet = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'Trinh_duyet
        '
        Me.Trinh_duyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Trinh_duyet.Location = New System.Drawing.Point(0, 0)
        Me.Trinh_duyet.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Trinh_duyet.Name = "Trinh_duyet"
        Me.Trinh_duyet.Size = New System.Drawing.Size(150, 150)
        Me.Trinh_duyet.TabIndex = 0
        '
        'MH_Dat_San_pham
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Trinh_duyet)
        Me.Name = "MH_Dat_San_pham"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Trinh_duyet As WebBrowser
End Class
