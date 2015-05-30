''' <summary>
''' Rappresenta un generatore di labirinti
''' </summary>
Public Class MazeGenerator
    Inherits RandomMapGenerator

    ''' <summary>
    ''' Ottiene o imposta le flag per lo startPoint
    ''' </summary>
    Protected flagSP As flagStartPoint
    ''' <summary>
    ''' Ottiene il punto iniziale
    ''' </summary>
    ''' <remarks></remarks>
    Protected StartPoint As Coord
    ''' <summary>
    ''' Ottiene o imposta la modalità di sviluppo del labirinto
    ''' </summary>
    Protected mazeMode As mazeMode

    ''' <summary>
    ''' Ottiene o imposta il tile che rappresenta il muro
    ''' </summary>
    Protected wallTile As ITile
    ''' <summary>
    ''' Ottiene o imposta il tile che rappresenta il pavimento
    ''' </summary>
    Protected floorTile As ITile

    ''' <summary>
    ''' Ottiene o imposta la lista che contiene le direzioni di espansione
    ''' </summary>
    Protected directionVector As List(Of Direction)

    ''' <summary>
    ''' Ottiene o imposta la struttura dati che contiene il branch
    ''' </summary>
    Protected branchStack As Stack(Of Coord)

    ''' <summary>
    ''' Crea una nuova istanza di mazegenerator
    ''' </summary>
    ''' <param name="random">Generatore di numeri casuali da utilizzare</param>
    ''' <param name="floor">Tile come pavimento</param>
    ''' <param name="wall">Tile come muro</param>
    ''' <param name="mazeMode">Modalità di espansione del labirinto</param>
    ''' <param name="FlagStartPoint">Punto iniziale</param>
    Public Sub New(random As IRandomGenerator, floor As ITile, wall As ITile, Optional mazeMode As mazeMode = GridBasedLibrary.mazeMode.CLEAN Or GridBasedLibrary.mazeMode.SQUARE, Optional FlagStartPoint As flagStartPoint = flagStartPoint.DOWN Or flagStartPoint.UP Or flagStartPoint.LEFT Or flagStartPoint.RIGHT)
        'crea mybase
        MyBase.New(random)
        'esegue la verifica sui parametri
        If floor Is Nothing Then Throw New NullReferenceException("FloorTile è nothing")
        If wall Is Nothing Then Throw New NullReferenceException("WallTile è nothing")
        'imposta i parametri
        Me.floorTile = floor
        Me.wallTile = wall
        Me.mazeMode = mazeMode
        Me.flagSP = FlagStartPoint
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di mazegenerator
    ''' </summary>
    ''' <param name="random">Generatore di numeri casuali da utilizzare</param>
    ''' <param name="floor">Tile come pavimento</param>
    ''' <param name="wall">Tile come muro</param>
    ''' <param name="mazeMode">Modalità di espansione del labirinto</param>
    ''' <param name="FlagStartPoint">Punto iniziale</param>
    Public Sub New(random As IRandomGenerator, floor As ITile, wall As ITile, startPoint As ILocated, Optional mazeMode As mazeMode = GridBasedLibrary.mazeMode.CLEAN Or GridBasedLibrary.mazeMode.SQUARE, Optional FlagStartPoint As flagStartPoint = flagStartPoint.DOWN Or flagStartPoint.UP Or flagStartPoint.LEFT Or flagStartPoint.RIGHT)
        'crea mybase
        MyBase.New(random)
        'esegue la verifica sui parametri
        If floor Is Nothing Then Throw New NullReferenceException("FloorTile è nothing")
        If wall Is Nothing Then Throw New NullReferenceException("WallTile è nothing")
        'imposta i parametri
        Me.floorTile = floor
        Me.wallTile = wall
        Me.mazeMode = mazeMode
        Me.flagSP = FlagStartPoint
        Me.StartPoint = startPoint
    End Sub

    ''' <summary>
    ''' Genera il labirinto
    ''' </summary>
    Protected Overrides Sub Generate()
        'mette i muri su tutta la region
        REM esegue la verifica se impostare i muri(da flag mazemode)
        SetWallRegion()
        'crea il punto iniziale
        MakeStartPoint()
        'crea il vettore delle direzioni
        InitDirectionVector()
        'crea il primo ramo
        MakeFirstBranch()
        'crea gli altri rami
        MakeOtherBranch()
    End Sub

    ''' <summary>
    ''' Imposta i muri su tutta la regione
    ''' </summary>
    Protected Overridable Sub SetWallRegion()
        'verifica che la flag di cancellamento è impostato
        If mazeMode.HasFlag(GridBasedLibrary.mazeMode.CLEAN) Then
            'imposta il muro su tutta la regione
            For x = region.GetX To region.GetX + region.GetWidth - 1
                For y = region.GetY To region.GetY + region.GetHeight - 1
                    'imposta il muro
                    SetWall(x, y)
                Next
            Next
        End If
    End Sub

    ''' <summary>
    ''' Imposta il muro alla cordinata specificata 
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    Protected Overridable Sub SetWall(x As Integer, y As Integer)
        'imposta il muro
        If map.IsValid(x, y) Then map.SetTile(x, y, wallTile)
    End Sub
    ''' <summary>
    ''' Imposta il muro alla cordinata specificata 
    ''' </summary>
    ''' <param name="c">Cordinata</param>
    Protected Overridable Sub SetWall(c As ILocated)
        'imposta il muro
        If map.IsValid(c) Then map.SetTile(c, wallTile)
    End Sub
    ''' <summary>
    ''' Imposta il pavimento alla cordinata specificata 
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    Protected Overridable Sub Dig(x As Integer, y As Integer)
        'imposta il muro
        If map.IsValid(x, y) Then map.SetTile(x, y, floorTile)
    End Sub
    ''' <summary>
    ''' Imposta il pavimento alla cordinata specificata 
    ''' </summary>
    ''' <param name="c">Cordinata</param>
    Protected Overridable Sub Dig(c As ILocated)
        'imposta il muro
        If map.IsValid(c) Then map.SetTile(c, floorTile)
    End Sub


    ''' <summary>
    ''' Ottiene il punto iniziale del labirinto
    ''' </summary>
    ''' <returns>Il punto iniziale del labirinto</returns>
    ''' <remarks>Il valore ha senso solo dopo con la creazione di un labirinto</remarks>
    Public Overridable Function getStartPoint() As Coord
        'restituisce il punto iniziale
        Return StartPoint
    End Function

    ''' <summary>
    ''' Crea il punto iniziale
    ''' </summary>
    Protected Overridable Sub MakeStartPoint()
        'se la flag NONE di start point è considerato customizzato, il metodo si interrompe implicando che quello già impostato è il punto iniziale
        REM può portare a errori nel caso che la stessa istanza di mazegenerator viene usato 2 volte di seguito
        If flagSP = flagStartPoint.NONE Then Return
        'crea il listSelecter con i punti iniziali possibili
        Dim list As New ListCoordSelecter()
        'riempe i punti lato sx
        If flagSP.HasFlag(flagStartPoint.LEFT) Then
            'il punto all' angolo non viene selezionato
            For y = region.GetY + 1 To region.GetY + region.GetHeight - 2
                list.Select(region.GetX, y)
            Next
        End If
        'riempe i punti lato dx
        If flagSP.HasFlag(flagStartPoint.RIGHT) Then
            'il punto all' angolo non viene selezionato
            For y = region.GetY + 1 To region.GetY + region.GetHeight - 2
                list.Select(region.GetX + region.GetWidth - 1, y)
            Next
        End If
        'riempe i punti lato su
        If flagSP.HasFlag(flagStartPoint.UP) Then
            'il punto all' angolo non viene selezionato
            For x = region.GetX + 1 To region.GetX + region.GetWidth - 2
                list.Select(x, region.GetY)
            Next
        End If
        'riempe i punti lato giù
        If flagSP.HasFlag(flagStartPoint.DOWN) Then
            'il punto all' angolo non viene selezionato
            For x = region.GetX + 1 To region.GetX + region.GetWidth - 2
                list.Select(x, region.GetY + region.GetHeight - 1)
            Next
        End If
        'verifica se deve ignorare gli angoli
        If Not flagSP.HasFlag(flagStartPoint.IGNORE_ANGLE) Then
            'se in modalità DOUBLE_SIDE_ANGLE esegue la verifica sui lati adiacenti
            If flagSP.HasFlag(flagStartPoint.DOUBLE_SIDE_ANGLE) Then
                'verifica lato sx-su
                If flagSP.HasFlag(flagStartPoint.LEFT) And flagSP.HasFlag(flagStartPoint.UP) Then
                    'seleziona il punto
                    list.Select(region.GetX, region.GetY)
                End If
                'verifica lato sx-giu
                If flagSP.HasFlag(flagStartPoint.LEFT) And flagSP.HasFlag(flagStartPoint.DOWN) Then
                    'seleziona il punto
                    list.Select(region.GetX, region.GetY + region.GetWidth - 1)
                End If
                'verifica lato dx-su
                If flagSP.HasFlag(flagStartPoint.RIGHT) And flagSP.HasFlag(flagStartPoint.UP) Then
                    'seleziona il punto
                    list.Select(region.GetX + region.GetWidth - 1, region.GetY)
                End If
                'verifica lato sx-giu
                If flagSP.HasFlag(flagStartPoint.RIGHT) And flagSP.HasFlag(flagStartPoint.DOWN) Then
                    'seleziona il punto
                    list.Select(region.GetX + region.GetWidth - 1, region.GetY + region.GetWidth - 1)
                End If
            Else
                'non deve eseguire doppia verifica
                'verifica lato sx-su
                If flagSP.HasFlag(flagStartPoint.LEFT) Or flagSP.HasFlag(flagStartPoint.UP) Then
                    'seleziona il punto
                    list.Select(region.GetX, region.GetY)
                End If
                'verifica lato sx-giu
                If flagSP.HasFlag(flagStartPoint.LEFT) Or flagSP.HasFlag(flagStartPoint.DOWN) Then
                    'seleziona il punto
                    list.Select(region.GetX, region.GetY + region.GetWidth - 1)
                End If
                'verifica lato dx-su
                If flagSP.HasFlag(flagStartPoint.RIGHT) Or flagSP.HasFlag(flagStartPoint.UP) Then
                    'seleziona il punto
                    list.Select(region.GetX + region.GetWidth - 1, region.GetY)
                End If
                'verifica lato sx-giu
                If flagSP.HasFlag(flagStartPoint.RIGHT) Or flagSP.HasFlag(flagStartPoint.DOWN) Then
                    'seleziona il punto
                    list.Select(region.GetX + region.GetWidth - 1, region.GetY + region.GetWidth - 1)
                End If
            End If
            'viene estratto uno e impostato a start point
            StartPoint = RandomGenerator.NextItem(list)
        End If
    End Sub
    ''' <summary>
    ''' Inizializza il vettore delle direzioni
    ''' </summary>
    Protected Overridable Sub InitDirectionVector()
        'verifica che sia nothing --> viene assunto che sia già stato inizializzato
        If directionVector Is Nothing Then
            'istanzia directionVector
            directionVector = New List(Of Direction)
            'verifica le flag di espansione
            If mazeMode.HasFlag(mazeMode.UP) Then directionVector.Add(Direction.UP)
            If mazeMode.HasFlag(mazeMode.DOWN) Then directionVector.Add(Direction.DOWN)
            If mazeMode.HasFlag(mazeMode.LEFT) Then directionVector.Add(Direction.LEFT)
            If mazeMode.HasFlag(mazeMode.RIGHT) Then directionVector.Add(Direction.RIGHT)
            If mazeMode.HasFlag(mazeMode.LEFT_UP) Then directionVector.Add(Direction.LEFT_UP)
            If mazeMode.HasFlag(mazeMode.LEFT_DOWN) Then directionVector.Add(Direction.LEFT_DOWN)
            If mazeMode.HasFlag(mazeMode.RIGHT_UP) Then directionVector.Add(Direction.RIGHT_UP)
            If mazeMode.HasFlag(mazeMode.RIGHT_DOWN) Then directionVector.Add(Direction.RIGHT_DOWN)
        End If
    End Sub

    ''' <summary>
    ''' Crea il primo ramo
    ''' </summary>
    Protected Overridable Sub MakeFirstBranch()
        'istanzia lo stack del ramo
        branchStack = New Stack(Of Coord)
        'pusha la cordinata corrente cioè iniziale
        branchStack.Push(StartPoint)
        'scava il primo buco
        Dig(StartPoint)
        'crea il ramo
        MakeBranch(StartPoint)
    End Sub

    Protected Overridable Sub MakeBranch(CurrentPoint As Coord)
        'variabile che contiene le direzioni disponibili
        Dim AvaDir() As Direction = GetAvaliableDir(CurrentPoint)
        Dim SelectDir As Direction
        'cicla finchè ci sono punti da scavare
        While AvaDir.Count > 0
            'viene scelto una direzione casuale in AvaDir
            SelectDir = RandomGenerator.NextItem(Of Direction)(AvaDir)
            'scava i punti
            Dig(CurrentPoint.GetCoordByDirection(SelectDir, 1))
            Dig(CurrentPoint.GetCoordByDirection(SelectDir, 2))
            'sposta current point
            CurrentPoint = CurrentPoint.GetCoordByDirection(SelectDir, 2)
            'pusha la cordinata
            branchStack.Push(CurrentPoint)
            'ricontrolla le direzioni disponibili
            AvaDir = GetAvaliableDir(CurrentPoint)
        End While
    End Sub

    ''' <summary>
    ''' Crea gli altri rami
    ''' </summary>
    Protected Overridable Sub MakeOtherBranch()
        'Crea gli altri rami poppando lo stack dei rami, ramificando l'ultimo possibile
        'POPPA l'ultimo elemento entranto perchè non ha mai direzioni disponibile, e quindi durante l'esecuzione di branch sarebbe finito
        branchStack.Pop()
        'inizia il popping & topping di tutti gli elemnti
        While branchStack.Count > 0
            'crea il ramo relativo al branch a partire dall'ultima cordinata pushata(TOP su .net è peek)
            MakeBranch(branchStack.Peek)
            'poppa l'elemento (in questo punto non ha mai delle direzioni disponibili)
            branchStack.Pop() 'NB non è detto che corrisponde all'elemento toppato prima
        End While
    End Sub


    ''' <summary>
    ''' Ottiene elenco di direzioni di espansioni disponibili per il punto
    ''' </summary>
    ''' <param name="point">Punto di riferimento</param>
    ''' <returns>L'elenco di direzioni disponibili</returns>
    Protected Overridable Function GetAvaliableDir(point As ILocated) As Direction()
        'crea la lista
        Dim l As New List(Of Direction)
        'cicla ogni direzione
        For Each Dir As Direction In directionVector
            'esegue la verifica se sia possibile scavare 
            If IsDiggable(point.GetCoordByDirection(Dir, 1)) And IsDiggable(point.GetCoordByDirection(Dir, 2)) Then
                'in strict mode è necessario eseguire un ulteriore verifica
                If mazeMode.HasFlag(mazeMode.STRICT) Then
                    'verifica se scavabile La cordinata della direzione ruotatata di -1
                    If Not IsDiggable(point.GetCoordByDirection(Dir.GetRotate(-1), 1)) Then Continue For
                    'stessa cosa con cordinata +1
                    If Not IsDiggable(point.GetCoordByDirection(Dir.GetRotate(1), 1)) Then Continue For
                End If
                l.Add(Dir)
            End If
        Next
        'restituisce la lista sottoforma di coord()
        Return l.ToArray
    End Function

    ''' <summary>
    ''' Esegue la verifica se è scavabile
    ''' </summary>
    ''' <param name="point">Punto da verificare</param>
    ''' <returns>True se è scavabile, altrimenti false</returns>
    Protected Overridable Function IsDiggable(point As ILocated) As Boolean
        'verifica che non sia fuori dalla regione e mappa
        If Not region.Contains(point) Then Return False
        If Not map.IsValid(point) Then Return False
        'restituisce la verifica se muro
        Return map.GetTile(point).IsEqual(wallTile)
    End Function
    ''' <summary>
    ''' Esegue la verifica se è scavabile
    ''' </summary>
    ''' <param name="pointX">Cordinata X del punto da verificare</param>
    ''' <param name="pointY">Cordinata Y del punto da verificare</param>
    ''' <returns>True se è scavabile, altrimenti false</returns>
    Protected Overridable Function IsDiggable(pointX As Integer, pointY As Integer) As Boolean
        'verifica che non sia fuori dalla regione e mappa
        If Not region.Contains(pointX, pointY) Then Return False
        If Not map.IsValid(pointX, pointY) Then Return False
        'restituisce la verifica se muro
        Return map.GetTile(pointX, pointY).IsEqual(wallTile)
    End Function
End Class




