CREATE PROCEDURE [dbo].[SpAgregarPedido]
    @cant int,
    @idplatillo int,
    @direccion text

AS
    declare @idpedido int;
    declare @time time;
    declare @montopagar decimal;
    declare @costounitario decimal;

    SELECT @time = LTRIM(RIGHT(CONVERT(VARCHAR(20), GETDATE(), 100), 7));

    insert into Pedido (Fecha, HoraSolicitado, Direccion) values (GETDATE(), @time, @direccion);

    select @idpedido = max(id) from pedido;
    select @costounitario = Precio_Unitario from Platillo where id=@idplatillo;

    set @montopagar = @costounitario*@cant;

    insert into DetallePedido(Cantidad, MontoPagar, IdPedido, IdPlatillo)
    values (@cant, @montopagar, @idpedido,@idplatillo);


RETURN 0
