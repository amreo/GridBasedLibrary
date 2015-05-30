''' <summary>
''' Classe base per i generatori di mappe
''' </summary>
Public MustInherit Class MapGenerator
    Implements IMapGenerator

    ''' <summary>
    ''' Ottiene o imposta la mappa di riferimento
    ''' </summary>
    Protected map As IMap
    ''' <summary>
    ''' Ottiene la regione su cui generare
    ''' </summary>
    Protected region As Rectangle

    ''' <summary>
    ''' Genera la mappa su tutta mapRef
    ''' </summary>
    ''' <param name="mapRef">Mappa di riferimento</param>
    Sub Generate(ByVal mapRef As IMap) Implements IMapGenerator.Generate
        'imposta i parametri
        map = mapRef
        region = New Rectangle(mapRef.GetLocation, mapRef.GetSize)
        'genera la mappa
        Generate()
    End Sub
    ''' <summary>
    ''' Genera la mappa su mapRef su tutta la regione
    ''' </summary>
    ''' <param name="mapRef">Mappa di riferimento</param>
    ''' <param name="region">Regione su cui generare la mappa</param>
    Sub Generate(ByVal mapRef As IMap, region As Rectangle) Implements IMapGenerator.Generate
        'imposta i parametri
        map = mapRef
        Me.region = region
        'genera la mappa
        Generate()
    End Sub
    ''' <summary>
    ''' Genera la mappa su mapRef su tutta la regione
    ''' </summary>
    ''' <param name="mapRef">Mappa di riferimento</param>
    ''' <param name="regionC">Cordinata della regione</param>
    ''' <param name="regionS">Dimensioni dellla regione</param>
    Sub Generate(ByVal mapRef As IMap, regionC As ILocated, regionS As Size) Implements IMapGenerator.Generate
        'imposta i parametri
        map = mapRef
        Me.region = New Rectangle(regionC, regionS)
        'genera la mappa
        Generate()
    End Sub
    ''' <summary>
    ''' Genera la mappa su mapRef su tutta la regione
    ''' </summary>
    ''' <param name="mapRef">Mappa di riferimento</param>
    ''' z<param name="regionX">Cordinata x della regione</param>
    ''' <param name="regionY">Cordinata y della regione</param>
    ''' <param name="regionWidth">Larghezza della regione</param>
    ''' <param name="regionHeight">Altezza della regione</param>
    Sub Generate(ByVal mapRef As IMap, regionX As Integer, regionY As Integer, regionWidth As UInteger, regionHeight As UInteger) Implements IMapGenerator.Generate
        'imposta i parametri
        map = mapRef
        Me.region = New Rectangle(regionX, regionY, regionWidth, regionHeight)
        'genera la mappa
        Generate()
    End Sub

    ''' <summary>
    ''' Genera la mappa
    ''' </summary>
    Protected MustOverride Sub Generate()
End Class
