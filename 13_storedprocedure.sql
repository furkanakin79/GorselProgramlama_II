create procedure sp_Select_All_Personel
as
   select
      personel_no,
      ad,
      soyad
   from
      personel

execute sp_Select_All_Personel;


create procedure sp_Select_BirimNo
@birimno int
as
   select
      personel_no,
      ad,
      soyad
   from
      personel
   where  birim_no = @birimno;

execute sp_Select_BirimNo 2;


create procedure sp_Select_BirimNo2
   @birimno int,
   @percount int = 0 output
as
   select       
      personel_no,
      ad,
      soyad
   from personel
   where birim_no = @birimno;

   select  @percount = count(*)
   from personel
   where  birim_no = @birimno;

   return @percount


Declare @return_value int, @percount int

Execute @return_value=sp_Select_BirimNo2
@birimno=2,
@percount=@percount output

Select @percount as N'@ordercount'
Select 'Return value'=@return_value



Alter procedure sp_Select_All_Personel
as
   select
      personel_no,
      ad,
      soyad,
	  cinsiyet
   from
      personel

execute sp_Select_All_Personel;



Execute sp_helptext 'sp_Select_BirimNo2'



Execute sp_rename 'sp_Select_BirimNo2', 'sp_Select_BirimNoOutput' 



Drop procedure sp_Select_BirimNo2