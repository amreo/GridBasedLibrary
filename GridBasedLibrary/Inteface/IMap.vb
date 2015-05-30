''' <summary>
''' Interfaccia che rappresenta una mappa
''' </summary>
Public Interface IMap
    'Una MAPPA è definità come una griglia in cui le celle sono occuppate da IMapTile

    ''' <summary>
    ''' Restituisce il MapTile che si trova alla cordinata specificata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    ''' <returns>MapTile che si trova alla cordinata specificata</returns>
    Function GetMapTile(x As Integer, y As Integer) As IMapTile
    ''' <summary>
    ''' Restituisce il MapTile che si trova alla cordinata specificata
    ''' </summary>
    ''' <param name="c">Cordinata</param>
    ''' <returns>MapTile che si trova alla cordinata specificata</returns>
    Function GetMapTile(c As ILocated) As IMapTile

    ''' <summary>
    ''' Restituisce il Tile che si trova alla cordinata specificata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    ''' <returns>MapTile che si trova alla cordinata specificata</returns>
    Function GetTile(x As Integer, y As Integer) As ITile
    ''' <summary>
    ''' Restituisce il Tile che si trova alla cordinata specificata
    ''' </summary>
    ''' <param name="c">Cordinata</param>
    ''' <returns>MapTile che si trova alla cordinata specificata</returns>
    Function GetTile(c As ILocated) As ITile

    ''' <summary>
    ''' Ottiene il tile di default usato nelle maptile senza tile
    ''' </summary>
    ''' <returns>Tile di default</returns>
    Function GetDefaultTile() As ITile

    ''' <summary>
    ''' Restituisce le dimensioni della mappa
    ''' </summary>
    ''' <returns>Le dimensioni</returns>
    Function GetSize() As Size
    ''' <summary>
    ''' Restituisce la locazione della mappa
    ''' </summary>
    ''' <returns>Locazione della mappa</returns>
    Function GetLocation() As Coord

    ''' <summary>
    ''' Imposta il tile alla cordinata specificata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    ''' <param name="newTile">Nuovo tile</param>
    Sub SetTile(x As Integer, y As Integer, newTile As ITile)
    ''' <summary>
    ''' Imposta il tile alla cordinata specificata
    ''' </summary>
    ''' <param name="dest">Cordinata x</param>
    ''' <param name="newTile">Nuovo tile</param>
    ''' <exception cref="ArgumentNullException">Si verifica quando dest è nothing</exception>
    Sub SetTile(dest As ILocated, newTile As ITile)

    ''' <summary>
    ''' Imposta il tile di default
    ''' </summary>
    ''' <param name="newTile">Nuovo tile</param>
    ''' <exception cref="ArgumentNullException">Si verifica quando newtile è nothing</exception>
    Sub SetDefaultTile(newTile As ITile)

    ''' <summary>
    ''' Inizializza i tile
    ''' </summary>
    Sub InitMap()

    ''' <summary>
    ''' Verifica che la cordinata è valida nella mappa
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    ''' <returns>True se è valida, altrimenti false</returns>
    Function IsValid(c As ILocated) As Boolean
    ''' <summary>
    ''' Verifica che la cordinata è valida nella mappa
    ''' </summary>
    ''' <param name="cX">Cordinata X</param>
    ''' <param name="cY">Cordinat Y</param>
    ''' <returns>True se è valida, altrimenti false</returns>
    Function IsValid(cX As Integer, cY As Integer) As Boolean

    ''' <summary>
    ''' Viene notificato a IMap che l'attore ha cambiato posizione
    ''' </summary>
    ''' <param name="act">Attore che si è spostato</param>
    ''' <param name="src">Sorgente</param>
    ''' <param name="dest">Destinazione</param>
    Sub NotifyChange(act As IActor, src As IMapTile, dest As IMapTile)

    ''' <summary>
    ''' Imposta l'attore sulla mappa (in modo insicuro)
    ''' </summary>
    ''' <param name="act">Attore da impostare</param>
    Sub SetActor(ByVal act As IActor)
    ''' <summary>
    ''' Restituisce l'attore presente nella cordinata
    ''' </summary>
    ''' <param name="c">Cordinata</param>
    ''' <returns>Attore che è presente</returns>
    ''' <remarks>Se non è presente alcun attore restituisce Nothing</remarks>
    Function GetActor(c As ILocated) As IActor
    ''' <summary>
    ''' Restituisce l'attore presente nella cordinata
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <returns>Attore che è presente</returns>
    ''' <remarks>Se non è presente alcun attore restituisce Nothing</remarks>
    Function GetActor(x As Integer, y As Integer) As IActor
    ''' <summary>
    ''' Despawna l'attore
    ''' </summary>
    ''' <param name="act">Attore da despawnare</param>
    Sub DespawnActor(ByVal act As IActor)
End Interface
