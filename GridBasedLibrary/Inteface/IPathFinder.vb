''' <summary>
''' Interfaccia di un path Finder
''' </summary>
Public Interface IPathFinder

    ''' <summary>
    ''' Cerca il percorso da src a dest per l'attore act
    ''' </summary>
    ''' <param name="act">Attore</param>
    ''' <param name="src">Punto iniziale</param>
    ''' <param name="dest">Punto finale</param>
    ''' <param name="map">Mappa di riferimento</param>
    ''' <returns>Percorso</returns>
    ''' <remarks>Questo metodo è utile maggiormente per attori ideali</remarks>
    Function Find(ByVal act As IActor, src As ILocated, dest As ILocated, map As IMap) As LinkedList(Of Coord)
    ''' <summary>
    ''' Cerca il percorso da src a dest per l'attore act
    ''' </summary>
    ''' <param name="act">Attore</param>
    ''' <param name="dest">Punto finale</param>
    ''' <returns>Percorso</returns>
    ''' <remarks>Il punto iniziale è la posizione dell' attore</remarks>
    Function Find(ByVal act As IActor, dest As ILocated) As LinkedList(Of Coord)
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
    ''' <remarks>Questo metodo è utile maggiormente per attori ideali</remarks>
    Function Find(ByVal act As IActor, srcX As Integer, srcY As Integer, destX As Integer, destY As Integer, map As IMap) As LinkedList(Of Coord)
    ''' <summary>
    ''' Cerca il percorso da src a dest per l'attore act
    ''' </summary>
    ''' <param name="act">Attore</param>
    ''' <param name="destX">Cordinata X del punto finale</param>
    ''' <param name="destY">Cordinata Y del punto finale</param>
    ''' <returns>Percorso</returns>
    ''' <remarks>Il punto iniziale è la posizione dell' attore</remarks>
    Function Find(ByVal act As IActor, destX As Integer, destY As Integer) As LinkedList(Of Coord)

End Interface
