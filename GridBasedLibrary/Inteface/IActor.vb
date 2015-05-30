''' <summary>
''' Interfaccia che rappresenta un attore
''' </summary>
Public Interface IActor
    Inherits IMovable

    ''' <summary>
    ''' Ottiene il mondo dell'attore
    ''' </summary>
    ''' <returns>Mappa dell'attore</returns>
    Function GetMap() As IMap


    ''' <summary>
    ''' Restituisce True se l'attore può muoversi verso il tile
    ''' </summary>
    ''' <param name="dest">Tile di destinazione</param>
    ''' <returns>True se può moversi</returns>
    ''' <remarks>Verifica soltanto se il tile è compatibile</remarks>
    Function CanMoveTo(dest As ITile) As Boolean

    ''' <summary>
    ''' Evento che si verifica quando sta per essere spostato
    ''' </summary>
    ''' <param name="dest">Destinazione</param>
    ''' <param name="cancel">True se cancellare l'evento</param>
    Event Moving(dest As IMapTile, ByRef cancel As Boolean)
    ''' <summary>
    ''' Evento che si verifica quando è arrivato a destinazione
    ''' </summary>
    ''' <param name="src">Provenienienza</param>
    Event Moved(src As IMapTile)

    ''' <summary>
    ''' Lancia l'evento Moving
    ''' </summary>
    ''' <param name="dest">Destinazione</param>
    ''' <returns>True se annullare l'azione</returns>
    Function OnMoving(dest As IMapTile) As Boolean
    ''' <summary>
    ''' Lancia l'evento Moved
    ''' </summary>
    ''' <param name="src">Provenienza</param>
    Sub OnMoved(src As IMapTile)


End Interface
