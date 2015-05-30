''' <summary>
''' Rappresenta un cercatore di percorsi che utilizza l'algoritmo A*
''' </summary>
''' <remarks>Utilizza algoritmo A*</remarks>
Public Class AStarPathFinder
    Inherits PathFinder

    'variabili usati dalla ricerca
    ''' <summary>
    ''' Ottiene o imposta i punti chiusi
    ''' </summary>
    Protected ClosedNodes As GridListCoordSelecter
    ''' <summary>
    ''' Ottiene o imposta la lista di nodi aperti
    ''' </summary>
    ''' <remarks>Un implementazione migliore sarebbe i prority queue</remarks>
    Protected OpenNodes As List(Of Coord)
    ''' <summary>
    ''' Ottiene o imposta i nodi 
    ''' </summary>
    Protected Nodes(,) As PathFinderNode
    ''' <summary>
    ''' Ottiene o imposta il vettore che contiene la lista di nodi
    ''' </summary>
    Protected DirVector As List(Of Direction)
    ''' <summary>
    ''' Ottiene o imposta la funzione euristica usata
    ''' </summary>
    Protected heuristicFunction As ICoordDistanceFunction
    ''' <summary>
    ''' Ottiene o imposta il valore di scala
    ''' </summary>
    Protected scale As Single

    ''' <summary>
    ''' Crea una nuova istanza di AStarPathFinder
    ''' </summary>
    ''' <param name="actDirections">Direzione che gli attori sono in grado di fare</param>
    Public Sub New(actDirections As ActorDirections, heuristicFunction As ICoordDistanceFunction, Optional scale As Single = 1.0)
        'chiama la classe base
        MyBase.New(actDirections)
        'verifica che heuristFunction non sia nothing
        If heuristicFunction Is Nothing Then Throw New NullReferenceException("HeuristicFunction non può essere nothing")
        'imposta HF e scale
        Me.heuristicFunction = heuristicFunction
        Me.scale = scale
        'crea il vettore delle direzioni
        DirVector = New List(Of Direction)
        'aggiunge le direzioni definite in actDirections
        'verifica le flag di espansione
        If actDirections.HasFlag(ActorDirections.UP) Then DirVector.Add(Direction.UP)
        If actDirections.HasFlag(ActorDirections.DOWN) Then DirVector.Add(Direction.DOWN)
        If actDirections.HasFlag(ActorDirections.LEFT) Then DirVector.Add(Direction.LEFT)
        If actDirections.HasFlag(ActorDirections.RIGHT) Then DirVector.Add(Direction.RIGHT)
        If actDirections.HasFlag(ActorDirections.LEFT_UP) Then DirVector.Add(Direction.LEFT_UP)
        If actDirections.HasFlag(ActorDirections.LEFT_DOWN) Then DirVector.Add(Direction.LEFT_DOWN)
        If actDirections.HasFlag(ActorDirections.RIGHT_UP) Then DirVector.Add(Direction.RIGHT_UP)
        If actDirections.HasFlag(ActorDirections.RIGHT_DOWN) Then DirVector.Add(Direction.RIGHT_DOWN)

    End Sub

    ''' <summary>
    ''' Cerca il percorso
    ''' </summary>
    ''' <returns>Percorso da trovare</returns>
    Protected Overloads Overrides Function Find() As LinkedList(Of Coord)
        'inizializza
        Init()
        'inizia la ricerca
        Return StartFind()
    End Function

    ''' <summary>
    ''' Inizializza le strutture dati usati nella ricerca
    ''' </summary>
    Protected Overridable Sub Init()
        'inizializza i closedNodes
        ClosedNodes = New GridListCoordSelecter(map.GetLocation, map.GetSize)
        'inizializza gli openNodes
        OpenNodes = New List(Of Coord)()
        'inizializza i nodi
        ReDim Nodes(map.GetSize.GetWidth, map.GetSize.GetHeight)
        'imposta i valori iniziali
        OpenNodes.Add(src.GetLocation)
        SetScoreH(src, heuristicFunction.GetDistance(src, dest, scale))
    End Sub

    ''' <summary>
    ''' Inizia la ricerca
    ''' </summary>
    Protected Overridable Function StartFind() As LinkedList(Of Coord)
        'cordinata corrente
        Dim currentIndex As Integer
        Dim currentCoord As Coord
        'cicla finchè openNodes non è vuoto
        While (OpenNodes.Count > 0)

            'ottiene il nodo con il minor punteggio f(complesivo)
            currentIndex = GetLowestScoreNodeIndex()
            currentCoord = OpenNodes(currentIndex)

            'verifica se corrisponde all' obbiettivo
            If currentCoord = dest.GetLocation Then
                'restituisce il percorso ricostruito all' indietro
                Return ReconstructPath()
            End If
            'rimuove currentCoord da openNodes
            OpenNodes.RemoveAt(currentIndex)
            'lo seleziona a closedNodes(definendolo chiuso)
            ClosedNodes.Select(currentCoord)
            'espande il nodo ai suoi vicini
            ExpandNode(currentCoord)
        End While
        'in questo punto è fallito. restituisce nothing
        Return Nothing
    End Function

    ''' <summary>
    ''' Espande il nodo corrente ai sui vicini
    ''' </summary>
    ''' <param name="currentNode">Nodo corrente da espandere</param>
    Protected Overridable Sub ExpandNode(currentNode As Coord)
        'variabile temporanea per il nodo
        Dim temp As Coord
        'punteggio g del nodo corrente
        Dim tempG As Single
        'cicla ogni direzione abilitata
        For Each Dir As Direction In DirVector
            'imposta temp con il nodo spostato
            temp = currentNode.GetCoordByDirection(Dir)
            'Salta la direzione se il nodo è già stato chiuso
            If ClosedNodes.IsSelected(temp) Then Continue For
            If Not map.IsValid(temp) Then Continue For
            If map.GetMapTile(temp).HasActor And temp.GetLocation <> dest.GetLocation Then Continue For
            If Not map.GetTile(temp).CanActorEnter(act) Then Continue For
            'calcola il punteggio g di temp
            tempG = GetScoreG(currentNode) + heuristicFunction.GetDistance(currentNode, temp) + map.GetTile(temp).GetScoreForPathFinder(act)
            'verifica che è nell'openNodes ed è migliore
            If Not OpenNodes.Contains(temp) Then
                'viene aggiunto a openNodes
                OpenNodes.Add(temp)
            ElseIf tempG >= GetScoreG(temp) Then
                'La relazione tra currentNode-temp rispetto a CameFrom-Temp
                'viene ignorato
                Continue For
            End If
            'vengono impostati i parametri
            SetCameFrom(temp, currentNode)
            SetScoreG(temp, tempG)
            SetScoreH(temp, heuristicFunction.GetDistance(temp, dest))
        Next
    End Sub

    ''' <summary>
    ''' Restituisce il percorso completo a ritroso
    ''' </summary>
    ''' <returns>Il percorso completo</returns>
    ''' <remarks>Si poteva implementare in maniera ricorsiva ma è meglio cosi per i percorsi lunghi che saturano lo stack</remarks>
    Protected Overridable Function ReconstructPath() As LinkedList(Of Coord)
        'crea la variabile path
        Dim path As New LinkedList(Of Coord)
        Dim currentNode As Coord = dest.GetLocation
        'aggiunge i nodi dall' ultimo
        While GetCameFrom(currentNode).GetLocation() <> src.GetLocation
            'aggiunge il punto all'inizio di path
            path.AddFirst(currentNode)
            'viene spostato all'indietro
            currentNode = GetCameFrom(currentNode)
        End While
        path.AddFirst(currentNode)
        'restituisce il percorso
        Return path
    End Function

    ''' <summary>
    ''' Imposta il punteggio G associato
    ''' </summary>
    ''' <param name="val">Valore da impostare</param>
    ''' <param name="c">Cordinata del punto</param>
    Protected Sub SetScoreG(c As ILocated, val As Single)
        'imposta il punteggio
        Nodes(c.GetX - map.GetLocation.GetX, c.GetY - map.GetLocation.GetY).SetScoreG(val)
    End Sub
    ''' <summary>
    ''' Imposta il punteggio G associato
    ''' </summary>
    ''' <param name="val">Valore da impostare</param>
    ''' <param name="c">Cordinata del punto</param>
    Protected Sub SetScoreH(c As ILocated, val As Single)
        'imposta il punteggio
        Nodes(c.GetX - map.GetLocation.GetX, c.GetY - map.GetLocation.GetY).SetScoreH(val)
    End Sub
    ''' <summary>
    ''' Imposta il punto di provenienza
    ''' </summary>
    ''' <param name="cf">Punto di provenienza</param>
    ''' <param name="c">Cordinata del punto</param>
    Protected Sub SetCameFrom(c As ILocated, ByVal cf As ILocated)
        'imposta il punto di provenienza
        Nodes(c.GetX - map.GetLocation.GetX, c.GetY - map.GetLocation.GetY).SetCameFrom(cf)
    End Sub
    ''' <summary>
    ''' Imposta il punto di provenienza
    ''' </summary>
    ''' <param name="x">Cordinata X del punto di provenienza</param>
    ''' <param name="y">Cordinata Y del punto di provenienza</param>
    ''' <param name="c">Cordinata del punto</param>
    Protected Sub SetCameFrom(c As ILocated, ByVal x As Integer, y As Integer)
        'imposta il punto di provenienza
        Nodes(c.GetX - map.GetLocation.GetX, c.GetY - map.GetLocation.GetY).SetCameFrom(x, y)
    End Sub
    ''' <summary>
    ''' Imposta il punteggio G associato
    ''' </summary>
    ''' <param name="val">Valore da impostare</param>
    ''' <param name="cX">Cordinata X del nodo</param>
    ''' <param name="cY">Cordinata Y del nodo</param>
    Protected Sub SetScoreG(cX As Integer, cY As Integer, val As Single)
        'imposta il punteggio
        Nodes(cX - map.GetLocation.GetX, cY - map.GetLocation.GetY).SetScoreG(val)
    End Sub
    ''' <summary>
    ''' Imposta il punteggio G associato
    ''' </summary>
    ''' <param name="val">Valore da impostare</param>
    ''' <param name="cX">Cordinata X del nodo</param>
    ''' <param name="cY">Cordinata Y del nodo</param>
    Protected Sub SetScoreH(cX As Integer, cY As Integer, val As Single)
        'imposta il punteggio
        Nodes(cX - map.GetLocation.GetX, cY - map.GetLocation.GetY).SetScoreH(val)
    End Sub
    ''' <summary>
    ''' Imposta il punto di provenienza
    ''' </summary>
    ''' <param name="cf">Punto di provenienza</param>
    ''' <param name="cX">Cordinata X del nodo</param>
    ''' <param name="cY">Cordinata Y del nodo</param>
    Protected Sub SetCameFrom(cX As Integer, cY As Integer, ByVal cf As ILocated)
        'imposta il punto di provenienza
        Nodes(cX - map.GetLocation.GetX, cY - map.GetLocation.GetY).SetCameFrom(cf)
    End Sub
    ''' <summary>
    ''' Imposta il punto di provenienza
    ''' </summary>
    ''' <param name="x">Cordinata X del punto di provenienza</param>
    ''' <param name="y">Cordinata Y del punto di provenienza</param>
    ''' <param name="cX">Cordinata X del nodo</param>
    ''' <param name="cY">Cordinata Y del nodo</param>
    Protected Sub SetCameFrom(cX As Integer, cY As Integer, ByVal x As Integer, y As Integer)
        'imposta il punto di provenienza
        Nodes(cX - map.GetLocation.GetX, cY - map.GetLocation.GetY).SetCameFrom(x, y)
    End Sub

    ''' <summary>
    ''' Restituisce il punteggio G
    ''' </summary>
    ''' <returns>Punteggio G</returns>
    ''' <param name="c">Cordinata del punto</param>
    Protected Function GetScoreG(c As ILocated) As Single
        'restituisce il punteggio
        Return Nodes(c.GetX - map.GetLocation.GetX, c.GetY - map.GetLocation.GetY).GetScoreG
    End Function
    ''' <summary>
    ''' Restituisce il punteggio H
    ''' </summary>
    ''' <returns>Punteggio H</returns>
    ''' <param name="c">Cordinata del punto</param>
    Protected Function GetScoreH(c As ILocated) As Single
        'restituisce il punteggio
        Return Nodes(c.GetX - map.GetLocation.GetX, c.GetY - map.GetLocation.GetY).GetScoreH
    End Function
    ''' <summary>
    ''' Restituisce il punteggio F
    ''' </summary>
    ''' <param name="c">Cordinata del punto</param>
    ''' <returns>Punteggio F</returns>
    Protected Function GetScoreF(c As ILocated) As Single
        'restituisce il punteggio
        Return Nodes(c.GetX - map.GetLocation.GetX, c.GetY - map.GetLocation.GetY).GetScoreF
    End Function
    ''' <summary>
    ''' Restituisce il punto di provenienza
    ''' </summary>
    ''' <param name="c">Cordinata del punto</param>
    ''' <returns>Cordinata di provenienza</returns>
    Protected Function GetCameFrom(c As ILocated) As Coord
        'restituisce la cordinata di provenienza
        Return Nodes(c.GetX - map.GetLocation.GetX, c.GetY - map.GetLocation.GetY).GetCameFrom
    End Function
    ''' <summary>
    ''' Restituisce il punteggio G
    ''' </summary>
    ''' <returns>Punteggio G</returns>
    ''' <param name="cX">Cordinata X del nodo</param>
    ''' <param name="cY">Cordinata Y del nodo</param>
    Protected Function GetScoreG(cX As Integer, cY As Integer) As Single
        'restituisce il punteggio
        Return Nodes(cX - map.GetLocation.GetX, cY - map.GetLocation.GetY).GetScoreG
    End Function
    ''' <summary>
    ''' Restituisce il punteggio H
    ''' </summary>
    ''' <returns>Punteggio H</returns>
    ''' <param name="cX">Cordinata X del nodo</param>
    ''' <param name="cY">Cordinata Y del nodo</param>
    Protected Function GetScoreH(cX As Integer, cY As Integer) As Single
        'restituisce il punteggio
        Return Nodes(cX - map.GetLocation.GetX, cY - map.GetLocation.GetY).GetScoreH
    End Function
    ''' <summary>
    ''' Restituisce il punteggio F
    ''' </summary>
    ''' <param name="cX">Cordinata X del nodo</param>
    ''' <param name="cY">Cordinata Y del nodo</param>
    ''' <returns>Punteggio F</returns>
    Protected Function GetScoreF(cX As Integer, cY As Integer) As Single
        'restituisce il punteggio
        Return Nodes(cX - map.GetLocation.GetX, cY - map.GetLocation.GetY).GetScoreF
    End Function
    ''' <summary>
    ''' Restituisce il punto di provenienza
    ''' </summary>
    ''' <param name="cX">Cordinata X del nodo</param>
    ''' <param name="cY">Cordinata Y del nodo</param>
    ''' <returns>Cordinata di provenienza</returns>
    Protected Function GetCameFrom(cX As Integer, cY As Integer) As Coord
        'restituisce la cordinata di provenienza
        Return Nodes(cX - map.GetLocation.GetX, cY - map.GetLocation.GetY).GetCameFrom
    End Function

    ''' <summary>
    ''' Ottiene o imposta indice del nodo in OpenNodes con il minor punteggio
    ''' </summary>
    ''' <returns>Il nodo con il minor numero F</returns>
    Protected Overridable Function GetLowestScoreNodeIndex() As Integer
        'ricerca il minore
        Dim minIndex As Integer = 0
        Dim minValue As Single = GetScoreF(OpenNodes(0))
        'ricerca il minore
        For i = 1 To OpenNodes.Count - 1
            'verifica se il punteggio f del nodo i è minore
            If GetScoreF(OpenNodes(i)) < minValue Then
                'imposta i nuovi valori
                minIndex = i
                minValue = GetScoreF(OpenNodes(minIndex))
            End If
        Next
        'restituisce minIndex
        Return minIndex
    End Function

End Class
