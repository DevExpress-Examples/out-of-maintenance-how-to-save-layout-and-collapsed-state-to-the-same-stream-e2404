Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraPivotGrid
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace WindowsApplication53
	Public Class PivotLayoutHelper
		Public Shared Sub SavePivot(ByVal pivot As PivotGridControl, ByVal stream As Stream)
			Dim s As New Storage()
			Using layoutStream As New MemoryStream()
				pivot.SaveLayoutToStream(layoutStream, PivotGridOptionsLayout.FullLayout)
				s.layout = layoutStream.ToArray()
			End Using
			Using stateStream As New MemoryStream()
				pivot.SaveCollapsedStateToStream(stateStream)
				s.collapsedState = stateStream.ToArray()
			End Using
			Dim binFormat As New BinaryFormatter()
			binFormat.Serialize(stream, s)

		End Sub
		Public Shared Sub LoadPivot(ByVal pivot As PivotGridControl, ByVal stream As Stream)
			Dim s As New Storage()

			Dim binFormat As New BinaryFormatter()
			s = TryCast(binFormat.Deserialize(stream), Storage)

			Using layoutStream As New MemoryStream()
				layoutStream.Write(s.layout, 0, s.layout.Length)
				layoutStream.Position = 0
				pivot.RestoreLayoutFromStream(layoutStream, PivotGridOptionsLayout.FullLayout)

			End Using
			Using stateStream As New MemoryStream()
				stateStream.Write(s.collapsedState, 0, s.collapsedState.Length)
				stateStream.Position = 0
				pivot.LoadCollapsedStateFromStream(stateStream)
			End Using

		End Sub

		<Serializable> _
		Public Class Storage
			Public layout() As Byte
			Public collapsedState() As Byte
		End Class
	End Class
End Namespace
