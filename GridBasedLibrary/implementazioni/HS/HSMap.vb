''' <summary>
''' Rappresenta una mappa
''' </summary>
''' <remarks>Utilizza un algoritmo basato sulla velocità</remarks>
Public Class HSMap
    Implements IMap

    ''' <summary>
    ''' Ottiene o imposta l'array che contiene la mappa
    ''' </summary>
    Protected grid(,) As IMapTile
    ''' <summary>
    ''' Ottiene o imposta la regione
    ''' </summary>
    Protected region As Rectangle
    ''' <summary>
    ''' Ottiene o imposta il default tile
    ''' </summary>
    Protected defaultTile As ITile
    ''' <summary>
    ''' Ottiene o imposta la lista di attori
    ''' </summary>
    Protected actorList As List(Of IActor)

    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    Protected Sub New(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger)
        'imposta le dimensioni
        region = New Rectangle(x, y, width, height)
        'ridimensiona grid
        ReDim grid(width, height)
        'crea la lista di attori
        actorList = New List(Of IActor)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger, defaultTile As ITile)
        'imposta le dimensioni
        region = New Rectangle(x, y, width, height)
        'imposta il defaulttile
        Me.defaultTile = defaultTile
        'ridimensiona grid
        ReDim grid(width, height)
        'crea la lista di attori
        actorList = New List(Of IActor)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Protected Sub New(c As Coord, size As Size)
        'imposta le dimensioni
        region = New Rectangle(c, size)
        'ridimensiona grid
        ReDim grid(size.GetWidth, size.GetHeight)
        'crea la lista di attori
        actorList = New List(Of IActor)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(c As Coord, size As Size, defaultTile As ITile)
        'imposta le dimensioni
        region = New Rectangle(c, size)
        'imposta il defaulttile
        Me.defaultTile = defaultTile
        'ridimensiona grid
        ReDim grid(size.GetWidth, size.GetHeight)
        'crea la lista di attori
        actorList = New List(Of IActor)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Protected Sub New(c As ILocated, size As Size)
        'imposta le dimensioni
        region = New Rectangle(c, size)
        'ridimensiona grid
        ReDim grid(size.GetWidth, size.GetHeight)
        'crea la lista di attori
        actorList = New List(Of IActor)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(c As ILocated, size As Size, defaultTile As ITile)
        'imposta le dimensioni
        region = New Rectangle(c, size)
        'imposta il defaulttile
        Me.defaultTile = defaultTile
        'ridimensiona grid
        ReDim grid(size.GetWidth, size.GetHeight)
        'crea la lista di attori
        actorList = New List(Of IActor)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    Protected Sub New(reg As Rectangle)
        'imposta le dimensioni
        region = New Rectangle(reg)
        'ridimensiona grid
        ReDim grid(reg.GetWidth, reg.GetHeight)
        'crea la lista di attori
        actorList = New List(Of IActor)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(reg As Rectangle, defaultTile As ITile)
        'imposta le dimensioni
        region = New Rectangle(reg)
        'imposta il defaulttile
        Me.defaultTile = defaultTile
        'ridimensiona grid
        ReDim grid(reg.GetWidth, reg.GetHeight)
        'crea la lista di attori
        actorList = New List(Of IActor)
    End Sub

    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    Public Shared Function CreateHSMap(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger) As HSMap
        'crea se stesso
        CreateHSMap = New HSMap(x, y, width, height)
        'cicla x e y per creare HSMapTile
        For y2 = y To y + height - 1
            For x2 = x To x + width - 1
                'imposta HSMapTile
                CreateHSMap.grid(x2, y2) = New HSMapTile(CreateHSMap, x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMap(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger, defaultTile As ITile) As HSMap
        'crea se stesso
        CreateHSMap = New HSMap(x, y, width, height, defaultTile)
        'cicla x e y per creare HSMapTile
        For y2 = y To y + height - 1
            For x2 = x To x + width - 1
                'imposta HSMapTile
                CreateHSMap.grid(x2, y2) = New HSMapTile(CreateHSMap, x2, y2)
                CreateHSMap.grid(x2, y2).SetTile(defaultTile.GetIstance)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Public Shared Function CreateHSMap(c As Coord, size As Size) As HSMap
        'crea se stesso
        CreateHSMap = New HSMap(c, size)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMap.grid(x2, y2) = New HSMapTile(CreateHSMap, x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMap(c As Coord, size As Size, defaultTile As ITile) As HSMap
        'crea se stesso
        CreateHSMap = New HSMap(c, size, defaultTile)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMap.grid(x2, y2) = New HSMapTile(CreateHSMap, x2, y2)
                CreateHSMap.grid(x2, y2).SetTile(defaultTile.GetIstance)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Public Shared Function CreateHSMap(c As ILocated, size As Size) As HSMap
        'crea se stesso
        CreateHSMap = New HSMap(c, size)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMap.grid(x2, y2) = New HSMapTile(CreateHSMap, x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMap(c As ILocated, size As Size, defaultTile As ITile) As HSMap
        'crea se stesso
        CreateHSMap = New HSMap(c, size, defaultTile)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMap.grid(x2, y2) = New HSMapTile(CreateHSMap, x2, y2)
                CreateHSMap.grid(x2, y2).SetTile(defaultTile.GetIstance)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    Public Shared Function CreateHSMap(reg As Rectangle) As HSMap
        'crea se stesso
        CreateHSMap = New HSMap(reg)
        'cicla x e y per creare HSMapTile
        For y2 = reg.GetY To reg.GetY + reg.GetHeight - 1
            For x2 = reg.GetX To reg.GetX + reg.GetWidth - 1
                'imposta HSMapTile
                CreateHSMap.grid(x2, y2) = New HSMapTile(CreateHSMap, x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMap(reg As Rectangle, defaultTile As ITile) As HSMap
        'crea se stesso
        CreateHSMap = New HSMap(reg, defaultTile)
        'cicla x e y per creare HSMapTile
        For y2 = reg.GetY To reg.GetY + reg.GetHeight - 1
            For x2 = reg.GetX To reg.GetX + reg.GetWidth - 1
                'imposta HSMapTile
                CreateHSMap.grid(x2, y2) = New HSMapTile(CreateHSMap, x2, y2)
                CreateHSMap.grid(x2, y2).SetTile(defaultTile.GetIstance)
            Next
        Next
    End Function


    ''' <summary>
    ''' Restituisce il MapTile che si trova alla cordinata specificata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    ''' <returns>MapTile che si trova alla cordinata specificata. Nothing se non è stata trovata</returns>
    Overridable Function GetMapTile(x As Integer, y As Integer) As IMapTile Implements IMap.GetMapTile
        'verifica l'esistenza del maptile
        If Not region.Contains(x, y) Then Return Nothing
        'restituisce il tile
        Return grid(x, y)
    End Function
    ''' <summary>
    ''' Restituisce il MapTile che si trova alla cordinata specificata
    ''' </summary>
    ''' <param name="c">Cordinata</param>
    ''' <returns>MapTile che si trova alla cordinata specificata</returns>
    Overridable Function GetMapTile(c As ILocated) As IMapTile Implements IMap.GetMapTile
        'verifica l'esistenza del maptile
        If Not region.Contains(c) Then Return Nothing
        'restituisce il tile
        Return grid(c.GetX, c.GetY)
    End Function

    ''' <summary>
    ''' Restituisce il Tile che si trova alla cordinata specificata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    ''' <returns>MapTile che si trova alla cordinata specificata. DefaultTile se non è impostato alcuntile</returns>
    Overridable Function GetTile(x As Integer, y As Integer) As ITile Implements IMap.GetTile
        'verifica che esiste il maptile
        Dim m As IMapTile = GetMapTile(x, y)
        'verifica che m sia nothing
        If m Is Nothing Then Return GetDefaultTile()
        'restituisce il tile
        Return m.GetTile
    End Function
    ''' <summary>
    ''' Restituisce il Tile che si trova alla cordinata specificata
    ''' </summary>
    ''' <param name="c">Cordinata</param>
    ''' <returns>MapTile che si trova alla cordinata specificata</returns>
    Overridable Function GetTile(c As ILocated) As ITile Implements IMap.GetTile
        'verifica che esiste il maptile
        Dim m As IMapTile = GetMapTile(c)
        'verifica che m sia nothing
        If m Is Nothing Then Return GetDefaultTile()
        'restituisce il tile
        Return m.GetTile
    End Function

    ''' <summary>
    ''' Ottiene il tile di default usato nelle maptile senza tile
    ''' </summary>
    ''' <returns>Tile di default</returns>
    Overridable Function GetDefaultTile() As ITile Implements IMap.GetDefaultTile
        'restituisce il default tile
        Return defaultTile
    End Function

    ''' <summary>
    ''' Restituisce le dimensioni della mappa
    ''' </summary>
    ''' <returns>Le dimensioni</returns>
    Overridable Function GetMapSize() As Size Implements IMap.GetSize
        'restituisce le dimensioni della mappa
        Return region.GetSize
    End Function
    ''' <summary>
    ''' Restituisce la locazione della mappa
    ''' </summary>
    ''' <returns>Locazione della mappa</returns>
    Overridable Function GetMapLocation() As Coord Implements IMap.GetLocation
        'restituisce la locazione della mappa
        Return region.GetLocation
    End Function

    ''' <summary>
    ''' Imposta il tile alla cordinata specificata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    ''' <param name="newTile">Nuovo tile</param>
    Overridable Sub SetTile(x As Integer, y As Integer, newTile As ITile) Implements IMap.SetTile
        'verifica che le cordinate siano corrette
        If region.Contains(x, y) Then GetMapTile(x, y).SetTile(newTile)
    End Sub
    ''' <summary>
    ''' Imposta il tile alla cordinata specificata
    ''' </summary>
    ''' <param name="dest">Cordinata x</param>
    ''' <param name="newTile">Nuovo tile</param>
    ''' <exception cref="ArgumentNullException">Si verifica quando dest è nothing</exception>
    Overridable Sub SetTile(dest As ILocated, newTile As ITile) Implements IMap.SetTile
        'verifica che le cordinate siano corrette
        If region.Contains(dest) Then GetMapTile(dest).SetTile(newTile)
    End Sub

    ''' <summary>
    ''' Imposta il tile di default
    ''' </summary>
    ''' <param name="newTile">Nuovo tile</param>
    ''' <exception cref="ArgumentNullException">Si verifica quando newtile è nothing</exception>
    Overridable Sub SetDefaultTile(newTile As ITile) Implements IMap.SetDefaultTile
        'imposta il tile di default
        defaultTile = newTile
    End Sub

    ''' <summary>
    ''' Inizializza i tile
    ''' </summary>
    Overridable Sub InitMap() Implements IMap.InitMap

    End Sub

    ''' <summary>
    ''' Verifica che la cordinata è valida nella mappa
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    ''' <returns>True se è valida, altrimenti false</returns>
    Overridable Function IsValid(c As ILocated) As Boolean Implements IMap.IsValid
        'verifica che sia valido
        Return region.Contains(c)
    End Function
    ''' <summary>
    ''' Verifica che la cordinata è valida nella mappa
    ''' </summary>
    ''' <param name="cX">Cordinata X</param>
    ''' <param name="cY">Cordinat Y</param>
    ''' <returns>True se è valida, altrimenti false</returns>
    Overridable Function IsValid(cX As Integer, cY As Integer) As Boolean Implements IMap.IsValid
        'verifica che sia valido
        Return region.Contains(cX, cY)
    End Function

    ''' <summary>
    ''' Viene notificato a IMap che l'attore ha cambiato posizione
    ''' </summary>
    ''' <param name="act">Attore che si è spostato</param>
    ''' <param name="src">Sorgente</param>
    ''' <param name="dest">Destinazione</param>
    Overridable Sub NotifyChange(act As IActor, src As IMapTile, dest As IMapTile) Implements IMap.NotifyChange

    End Sub

    ''' <summary>
    ''' Imposta l'attore sulla mappa (in modo insicuro)
    ''' </summary>
    ''' <param name="act">Attore da impostare</param>
    Overridable Sub SetActor(ByVal act As IActor) Implements IMap.SetActor
        'imposta l'attore aggiungendo alla lista
        'controlla se è già presente
        If actorList.Contains(act) Then Return
        'aggiunge l'attore
        actorList.Add(act)
    End Sub
    ''' <summary>
    ''' Restituisce l'attore presente nella cordinata
    ''' </summary>
    ''' <param name="c">Cordinata</param>
    ''' <returns>Attore che è presente</returns>
    ''' <remarks>Se non è presente alcun attore restituisce Nothing</remarks>
    Overridable Function GetActor(c As ILocated) As IActor Implements IMap.GetActor
        'restituisce l'attore
        Return GetMapTile(c).GetActor()
    End Function
    ''' <summary>
    ''' Restituisce l'attore presente nella cordinata
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <returns>Attore che è presente</returns>
    ''' <remarks>Se non è presente alcun attore restituisce Nothing</remarks>
    Overridable Function GetActor(x As Integer, y As Integer) As IActor Implements IMap.GetActor
        'restituisce l'attore
        Return GetMapTile(x, y).GetActor()
    End Function
    ''' <summary>
    ''' Despawna l'attore
    ''' </summary>
    ''' <param name="act">Attore da despawnare</param>
    Overridable Sub DespawnActor(ByVal act As IActor) Implements IMap.DespawnActor
        'verifica che l'attore sia valido
        If act Is Nothing Then Return
        'lo rimuove sia dalla lista che da maptile
        actorList.Remove(act)
        GetMapTile(act).SetActor(Nothing)
        'notifica con gli eventi
        GetMapTile(act).GetTile().OnActorLeaved(act, GetMapTile(act), Nothing)
        NotifyChange(act, GetMapTile(act), Nothing)
    End Sub
End Class
