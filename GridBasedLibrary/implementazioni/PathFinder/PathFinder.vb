''' <summary>
''' Rappresenta un pathFinder
''' </summary>
Public MustInherit Class PathFinder
    Implements IPathFinder

    ''' <summary>
    ''' Ottiene o imposta l'attore di riferimento
    ''' </summary>
    Protected act As IActor
    ''' <summary>
    ''' Ottiene o imposta il punto iniziale
    ''' </summary>
    Protected src As ILocated
    ''' <summary>
    ''' Ottiene o imposta il punto finale
    ''' </summary>
    Protected dest As ILocated
    ''' <summary>
    ''' Ottiene o imposta la mappa
    ''' </summary>
    Protected map As IMap
    ''' <summary>
    ''' Ottiene o imposta le direzioni in cui l'attore è in grado di fare
    ''' </summary>
    Protected actorDirectionsMode As ActorDirections
    ''' <summary>
    ''' Crea una nuova istanza di actor Directions
    ''' </summary>
    ''' <param name="actDirections">Direzione dell' attore</param>
    Protected Sub New(actDirections As ActorDirections)
        'imposta il parametro
        actorDirectionsMode = actDirections
    End Sub

    ''' <summary>
    ''' Cerca il percorso da src a dest per l'attore act
    ''' </summary>
    ''' <param name="act">Attore</param>
    ''' <param name="src">Punto iniziale</param>
    ''' <param name="dest">Punto finale</param>
    ''' <param name="map">Mappa di riferimento</param>
    ''' <returns>Percorso</returns>
    ''' <remarks>Questo metodo è utile maggiormente per attori ideali</remarks>
    Function Find(ByVal act As IActor, src As ILocated, dest As ILocated, map As IMap) As LinkedList(Of Coord) Implements IPathFinder.Find
        'verifica la correttezza dei parametri
        If act Is Nothing Then Throw New Exception("L'attore non può essere nothing")
        If src Is Nothing Then Throw New Exception("Src non può essere nothing")
        If dest Is Nothing Then Throw New Exception("Dest non può essere nothing")
        If map Is Nothing Then Throw New Exception("Map non può essere nothing")
        'imposta i parametri
        Me.act = act
        Me.src = src
        Me.dest = dest
        Me.map = map
        'esegue la ricerca
        Return Find()
    End Function
    ''' <summary>
    ''' Cerca il percorso da src a dest per l'attore act
    ''' </summary>
    ''' <param name="act">Attore</param>
    ''' <param name="dest">Punto finale</param>
    ''' <returns>Percorso</returns>
    ''' <remarks>Il punto iniziale è la posizione dell' attore</remarks>
    Function Find(ByVal act As IActor, dest As ILocated) As LinkedList(Of Coord) Implements IPathFinder.Find
        'verifica la correttezza dei parametri
        If act Is Nothing Then Throw New Exception("L'attore non può essere nothing")
        If dest Is Nothing Then Throw New Exception("Dest non può essere nothing")
        'imposta i parametri
        Me.act = act
        Me.src = act
        Me.dest = dest
        Me.map = act.GetMap
        'esegue la ricerca
        Return Find()
    End Function
    ''' <summary>
    ''' Cerca il percorso da src a dest per l'attore act
    ''' </summary>
    ''' <param name="act">Attore</param>
    ''' <param name="destX">Cordinata X del punto finale</param>
    ''' <param name="destY">Cordinata Y del punto finale</param>
    ''' <param name="srcX">Cordinata X del punto iniziale</param>
    ''' <param name="srcY">Cordinata Y del punto iniziale</param>
    ''' <param name="map">Mappa di riferimento</param>
    ''' <returns>Percorso</returns>
    ''' <remarks>Src non è necessario per attori reali, ma viene considerato src come punto iniziale</remarks>
    Function Find(ByVal act As IActor, srcX As Integer, srcY As Integer, destX As Integer, destY As Integer, map As IMap) As LinkedList(Of Coord) Implements IPathFinder.Find
        'verifica la correttezza dei parametri
        If act Is Nothing Then Throw New Exception("L'attore non può essere nothing")
        If map Is Nothing Then Throw New Exception("Map non può essere nothing")
        'imposta i parametri
        Me.act = act
        Me.src = New Coord(srcX, srcY)
        Me.dest = New Coord(destX, destY)
        Me.map = map
        'esegue la ricerca
        Return Find()
    End Function
    ''' <summary>
    ''' Cerca il percorso da src a dest per l'attore act
    ''' </summary>
    ''' <param name="act">Attore</param>
    ''' <param name="destX">Cordinata X del punto finale</param>
    ''' <param name="destY">Cordinata Y del punto finale</param>
    ''' <returns>Percorso</returns>
    ''' <remarks>Il punto iniziale è la posizione dell' attore</remarks>
    Function Find(ByVal act As IActor, destX As Integer, destY As Integer) As LinkedList(Of Coord) Implements IPathFinder.Find
        'verifica la correttezza dei parametri
        If act Is Nothing Then Throw New Exception("L'attore non può essere nothing")
        If dest Is Nothing Then Throw New Exception("Dest non può essere nothing")
        'imposta i parametri
        Me.act = act
        Me.src = act
        Me.dest = New Coord(destX, destY)
        Me.map = act.GetMap
        'esegue la ricerca
        Return Find()
    End Function

    ''' <summary>
    ''' Cerca il percorso
    ''' </summary>
    ''' <returns>Percorso da trovare</returns>
    Protected MustOverride Function Find() As LinkedList(Of Coord)

End Class
