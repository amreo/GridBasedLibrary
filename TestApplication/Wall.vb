
Public Class Wall
    Inherits GridBasedLibrary.HSTile


    Sub New()
        MyBase.New("wall")
    End Sub
    Public Overrides Function OnActorEntering(act As GridBasedLibrary.IActor, from As GridBasedLibrary.IMapTile, dest As GridBasedLibrary.IMapTile) As Boolean
        Return False
    End Function

    Public Overrides Function CanActorEnter(act As GridBasedLibrary.IActor) As Boolean
        Return False
    End Function

    Public Overrides Function GetScoreForPathFinder(act As GridBasedLibrary.IActor) As Single
        Return Single.PositiveInfinity
    End Function
End Class
