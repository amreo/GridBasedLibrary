''' <summary>
''' Rappresenta un tile generico
''' </summary>
''' <remarks>Utilizza un algoritmo preferenziale per la velocità</remarks>
<Serializable()>
Public Class HSTile
    Implements ITile


    ''' <summary>
    ''' Ottiene o imposta il nome del tile
    ''' </summary>
    Protected name As String
    ''' <summary>
    ''' Ottiene o imposta un valore booleano che indica se è condiviso o no
    ''' </summary>
    Protected [static] As Boolean

    ''' <summary>
    ''' Crea una nuova istanza di HSTile
    ''' </summary>
    ''' <param name="name">Nome da usare</param>
    Public Sub New(ByVal name As String, Optional [static] As Boolean = True)
        'imposta i parametri
        Me.name = name
        Me.static = [static]
    End Sub

    ''' <summary>
    ''' Restituisce una copia di se stesso
    ''' </summary>
    ''' <returns>Una copia di se stesso</returns>
    Public Overridable Function GetCopy() As ITile Implements ITile.GetCopy
        'restituisce una copia di se stesso
        Return Me.MemberwiseClone
    End Function
    ''' <summary>
    ''' Restituisce una copia di se stesso se non è statico oppure se stesso
    ''' </summary>
    ''' <returns>Se statico restituisce se stesso, invece se non statico una copia</returns>
    ''' <remarks></remarks>
    Public Overridable Function GetIstance() As ITile Implements ITile.GetIstance
        'in base se statico o no restituisce un riferimento
        If IsStatic() Then
            'restituisce se stesso
            Return Me
        Else
            'restituisce una copia
            Return GetCopy()
        End If
    End Function
    ''' <summary>
    ''' Restituisce true se è condiviso
    ''' </summary>
    ''' <returns>True se è condiviso</returns>
    Public Overridable Function IsStatic() As Boolean Implements ITile.IsStatic
        'restituisce il valore della variabile static
        Return [static]
    End Function

    ''' <summary>
    ''' Restituisce il punteggio usato dai pathFinder
    ''' </summary>
    ''' <param name="act">Il punteggio può variare per l'attore</param>
    ''' <returns>Il punteggio</returns>
    ''' <remarks>Il punteggio potrebbe dipendere dall' attore</remarks>
    Overridable Function GetScoreForPathFinder(act As IActor) As Single Implements ITile.GetScoreForPathFinder
        'restituisce 0
        Return 0
    End Function
    ''' <summary>
    ''' Ottiene il nome assegnato al tile
    ''' </summary>
    ''' <returns>Il nome</returns>
    Public Overridable Function GetName() As String Implements ITile.GetName
        'restituisce il nome
        Return name
    End Function

    ''' <summary>
    ''' Inizializza il tile con il maptile di riferimento
    ''' </summary>
    ''' <param name="ref">MapTile di riferimento</param>
    Public Overridable Sub Init(ref As IMapTile) Implements ITile.Init

    End Sub

    ''' <summary>
    ''' Aggiorna il tile
    ''' </summary>
    ''' <param name="ref">MapTile di riferimento</param>
    Public Overridable Sub Update(ref As IMapTile) Implements ITile.Update

    End Sub

    ''' <summary>
    ''' Verifica che i 2 tile sono uguali o no
    ''' </summary>
    ''' <param name="tile2">Secondo tile</param>
    ''' <returns>True se sono uguali, altrimenti false</returns>
    Public Overridable Function IsEqual(tile2 As ITile) As Boolean Implements ITile.IsEqual
        'verifica se sono uguali
        Return Me.name = tile2.GetName
    End Function
    ''' <summary>
    ''' Restituisce true se sono uguali dal punto di vista grafico
    ''' </summary>
    ''' <param name="tile2">Secondo tile</param>
    ''' <returns>True se sono uguali dal punto di vista grafico</returns>
    Public Overridable Function IsRenderEqual(tile2 As ITile) As Boolean Implements ITile.IsRenderEqual
        'verifica se sono uguali
        Return Me.name = tile2.GetName
    End Function
    ''' <summary>
    ''' Evento che si verifica quando un attore è entrato
    ''' </summary>
    ''' <param name="act">Attore che è entrato</param>
    ''' <param name="from">MapTile di partenza</param> 
    ''' <param name="dest">MapTile di destinazione</param>
    Public Event ActorEntered(act As IActor, from As IMapTile, dest As IMapTile) Implements ITile.ActorEntered
    ''' <summary>
    ''' Evento che si verifica quando un attore sta per entrare in questo tile
    ''' </summary>
    ''' <param name="act">Attore che sta per entrare</param>
    ''' <param name="cancel">True se cancellare l'evento</param>
    ''' <param name="from">MapTile di partenza</param> 
    ''' <param name="dest">MapTile di destinazione</param>
    Public Event ActorEntering(act As IActor, from As IMapTile, dest As IMapTile, ByRef cancel As Boolean) Implements ITile.ActorEntering

    ''' <summary>
    ''' Lancia l'evento che si verifica quando un attore è entrato in questo tile
    ''' </summary>
    ''' <param name="act">Attore che ha compiuto l'azione</param>
    ''' <param name="from">TileMap di origine</param>
    ''' <param name="dest">MapTile di destinazione</param>
    Public Overridable Sub OnActorEntered(act As IActor, from As IMapTile, dest As IMapTile) Implements ITile.OnActorEntered
        'lancia l'evento
        RaiseEvent ActorEntered(act, [from], dest)
    End Sub
    ''' <summary>
    ''' Lancia l'evento che si verifica quando un attore sta per entrare in questo tile
    ''' </summary>
    ''' <param name="act">Attore che si spostato</param>
    ''' <param name="dest">MapTile di destinazione</param>
    ''' <returns>True se è stato rifiutato</returns>
    Public Overridable Function OnActorEntering(act As IActor, from As IMapTile, dest As IMapTile) As Boolean Implements ITile.OnActorEntering
        Dim canc As Boolean
        'lancia l'evento
        RaiseEvent ActorEntering(act, [from], dest, canc)
        'restituisce canc
        Return Not canc
    End Function

    ''' <summary>
    ''' Evento che si verifica quando un attore sta per lasciare questo tile
    ''' </summary>
    ''' <param name="act">Attore che sta per entrare</param>
    ''' <param name="cancel">True se cancellare l'evento</param>
    ''' <param name="from">MapTile di partenza</param> 
    ''' <param name="dest">MapTile di destinazione</param>
    Event ActorLeaving(act As IActor, from As IMapTile, dest As IMapTile, ByRef cancel As Boolean) Implements ITile.ActorLeaving
    ''' <summary>
    ''' Evento che si verifica quando un attore ha lasciato questo tile
    ''' </summary>
    ''' <param name="act">Attore che è entrato</param>
    ''' <param name="from">MapTile di partenza</param> 
    ''' <param name="dest">MapTile di destinazione</param>
    Event ActorLeaved(act As IActor, from As IMapTile, dest As IMapTile) Implements ITile.ActorLeaved

    ''' <summary>
    ''' Lancia l'evento che si verifica quando un attore sta per lasciare questo tile
    ''' </summary>
    ''' <param name="act">Attore che si spostato</param>
    ''' <param name="dest">MapTile di destinazione</param>
    ''' <returns>True se è stato rifiutato</returns>
    Function OnActorLeaving(act As IActor, from As IMapTile, dest As IMapTile) As Boolean Implements ITile.OnActorLeaving
        Dim canc As Boolean
        'lancia l'evento relativo
        RaiseEvent ActorLeaving(act, [from], dest, canc)
        'restituisce canc
        Return Not canc
    End Function
    ''' <summary>
    ''' Lancia l'evento che si verifica quando un attore ha lasciato questo tile
    ''' </summary>
    ''' <param name="act">Attore che ha compiuto l'azione</param>
    ''' <param name="from">TileMap di origine</param>
    ''' <param name="dest">MapTile di destinazione</param>
    Sub OnActorLeaved(act As IActor, from As IMapTile, dest As IMapTile) Implements ITile.OnActorLeaved
        'lancia l'evento leaved
        RaiseEvent ActorLeaved(act, from, dest)
    End Sub

    ''' <summary>
    ''' Restituisce true se l'attore può entrare nel tile
    ''' </summary>
    ''' <param name="act">Attore da verificare</param>
    ''' <returns>True se può entrare</returns>
    Public Overridable Function CanActorEnter(act As IActor) As Boolean Implements ITile.CanActorEnter
        'restituisce true
        Return True
    End Function
End Class
