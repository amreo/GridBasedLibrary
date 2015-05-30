''' <summary>
''' Rappresenta un cercatore di percorsi che utilizza l'algoritmo di Dijkstra
''' </summary>
Public Class DijkstraPathFinder
    Inherits AStarPathFinder

    ''' <summary>
    ''' Crea una nuova istanza di DijkstraPathFinder
    ''' </summary>
    ''' <param name="actDirections">Direzioni possibili</param>
    Public Sub New(actDirections As ActorDirections)
        'imposta il parametro
        MyBase.New(actDirections, NullDistanceFunction.DistanceFunction, 0)
    End Sub
End Class
