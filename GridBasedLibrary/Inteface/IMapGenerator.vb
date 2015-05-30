''' <summary>
''' Rappresenta un generatore di mappe
''' </summary>
Public Interface IMapGenerator

    ''' <summary>
    ''' Genera la mappa su tutta mapRef
    ''' </summary>
    ''' <param name="mapRef">Mappa di riferimento</param>
    Sub Generate(ByVal mapRef As IMap)
    ''' <summary>
    ''' Genera la mappa su mapRef su tutta la regione
    ''' </summary>
    ''' <param name="mapRef">Mappa di riferimento</param>
    ''' <param name="region">Regione su cui generare la mappa</param>
    Sub Generate(ByVal mapRef As IMap, region As Rectangle)
    ''' <summary>
    ''' Genera la mappa su mapRef su tutta la regione
    ''' </summary>
    ''' <param name="mapRef">Mappa di riferimento</param>
    ''' <param name="regionC">Cordinata della regione</param>
    ''' <param name="regionS">Dimensioni dellla regione</param>
    Sub Generate(ByVal mapRef As IMap, regionC As ILocated, regionS As Size)
    ''' <summary>
    ''' Genera la mappa su mapRef su tutta la regione
    ''' </summary>
    ''' <param name="mapRef">Mappa di riferimento</param>
    ''' z<param name="regionX">Cordinata x della regione</param>
    ''' <param name="regionY">Cordinata y della regione</param>
    ''' <param name="regionWidth">Larghezza della regione</param>
    ''' <param name="regionHeight">Altezza della regione</param>
    Sub Generate(ByVal mapRef As IMap, regionX As Integer, regionY As Integer, regionWidth As UInteger, regionHeight As UInteger)
End Interface
