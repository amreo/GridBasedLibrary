''' <summary>
''' Classe che rappresenta l'attore di base
''' </summary>
Public MustInherit Class Actor
    Inherits Movable
    Implements IActor

    ''' <summary>
    ''' Ottiene o imposta la mappa dell'attore
    ''' </summary>
    Protected MapRef As IMap

    ''' <summary>
    ''' Restituisce True se l'attore può muoversi verso il tile
    ''' </summary>
    ''' <param name="dest">Tile di destinazione</param>
    ''' <returns>True se può moversi</returns>
    ''' <remarks>Verifica soltanto se il tile è compatibile</remarks>
    Public Overridable Function CanMoveTo(dest As ITile) As Boolean Implements IActor.CanMoveTo
        Return True
    End Function


    ''' <summary>
    ''' Ottiene il mondo dell'attore
    ''' </summary>
    ''' <returns>Mappa dell'attore</returns>
    Public Function GetMap() As IMap Implements IActor.GetMap
        'restituisce la mappa dell' attore
        Return MapRef
    End Function
    ''' <summary>
    ''' Evento che si verifica quando è arrivato a destinazione
    ''' </summary>
    ''' <param name="src">Provenienienza</param>
    Public Event Moved(src As IMapTile) Implements IActor.Moved
    ''' <summary>
    ''' Evento che si verifica quando sta per essere spostato
    ''' </summary>
    ''' <param name="dest">Destinazione</param>
    ''' <param name="cancel">True se cancellare l'evento</param>
    Public Event Moving(dest As IMapTile, ByRef cancel As Boolean) Implements IActor.Moving

    ''' <summary>
    ''' Lancia l'evento Moved
    ''' </summary>
    ''' <param name="src">Provenienza</param>
    Public Sub OnMoved(src As IMapTile) Implements IActor.OnMoved
        'lancia l''evento Moved
        RaiseEvent Moved(src)
    End Sub

    ''' <summary>
    ''' Lancia l'evento Moving
    ''' </summary>
    ''' <param name="dest">Destinazione</param>
    ''' <returns>True se annullare l'azione</returns>
    Public Function OnMoving(dest As IMapTile) As Boolean Implements IActor.OnMoving
        Dim cancel As Boolean
        'lancia l''evento Moved
        RaiseEvent Moving(dest, cancel)
        Return cancel
    End Function
End Class
