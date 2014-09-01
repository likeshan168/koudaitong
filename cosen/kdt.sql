
--记录上传过的商品时间
create table [dbo].[kdt_upload_item] (
    [id]         int          identity (1, 1) not null,
    [styleno]    varchar (50) not null,
    [colno]      varchar (50) null,
	[size]		 varchar (30) null,
    [uploadtime] varchar (30) null,
    primary key clustered ([id] asc)
);
go

--drop view kucun_kdt_view
--口袋通使用的库存视图
create  view  kucun_kdt_view
as

	SELECT Com_nm,replace(Sty_no,'','') Sty_no,
	Col_no,Col_dr,Siz_dr,Siz_no,Unt_pr,Sto_n1 Com_qu,siz_id--,isnull(up.uptime,'') uptime
	FROM eissy.dbo.vwS003 w
	--left join 
	--(
	--	select StyleNo,ColNo, max(UploadTime) uptime from kdt_upload_item 
	--	group by StyleNo,ColNo
	--) up on up.styleno+up.ColNo=replace(Sty_no,'','')+Col_no
	Where Del_bz<>'Y' and Sto_n1>0;
go



--获取库存汇总的存储过程

create proc kdt_style_kucun_proc
	@style_no varchar(30),--款式
	@style_name varchar(30),--款式名称
	@kucun_num decimal, --库存数
	@flag smallint,-- 标志位（提示按什么进行查询 1：款式 2：名称 3：库存 4：查询所有的信息）
	@page_num int--页码
as
	begin
		
		if @flag=1 --按款式进行查询
			begin
				select tmp.*,isnull(up.uptime,'') uptime from 
				(
					select row_number() over(order by Sty_no desc) row_num, sty_no,
					com_nm,CONVERT(decimal(10,2), sum(Com_qu)) kucun,
					convert(decimal(10,2),Unt_pr) unt_pr
					from kucun_kdt_view where
					Sty_no like '[^a-zA-Z]%' and Sty_no like @style_no+'%' 
					group by Sty_no,Com_nm,Unt_pr --order by Sty_no desc
				) tmp 
				left join 
				(
					select StyleNo, max(UploadTime) uptime from kdt_upload_item 
					group by StyleNo
				) up
				on up.styleno=tmp.sty_no

				where tmp.row_num between ((@page_num-1)*10+1) and @page_num*10

				if @page_num=1 --获取总页数
					begin
						select count(*) from 
						(
							select sty_no from kucun_kdt_view where
							Sty_no like '[^a-zA-Z]%' and Sty_no like @style_no+'%' 
							group by Sty_no,Com_nm,Unt_pr
						) tmp
					end
				--select count(*) from 
			end

			
			
			
		else if @flag=2 --按名称进行查询
			begin
				select tmp.*,isnull(up.uptime,'') uptime from 
				(
					select row_number() over(order by Sty_no desc) row_num,sty_no,
					com_nm,CONVERT(decimal(10,2), sum(Com_qu)) kucun,
					convert(decimal(10,2),Unt_pr) unt_pr
					from kucun_kdt_view where
					Sty_no like '[^a-zA-Z]%' and com_nm like @style_name+'%'
					group by Sty_no,Com_nm,Unt_pr-- order by Sty_no desc
				) tmp 
				left join 
				(
					select StyleNo, max(UploadTime) uptime from kdt_upload_item 
					group by StyleNo
				) up
				on up.styleno=tmp.sty_no
				where tmp.row_num between ((@page_num-1)*10+1) and @page_num*10
				
				if @page_num=1 --获取总页数
					begin
						select count(*) from
						(
							select sty_no from kucun_kdt_view where
							Sty_no like '[^a-zA-Z]%' and com_nm like @style_name+'%' 
							group by Sty_no,Com_nm,Unt_pr
						) tmp
					end 
			end
			
		else if @flag=3--按库存数
			begin
				select tmp.*,isnull(up.uptime,'') uptime from 
				(	
					select row_number() over(order by Sty_no desc) row_num,sty_no,
					com_nm,CONVERT(decimal(10,2), sum(Com_qu)) kucun,
					convert(decimal(10,2),Unt_pr) unt_pr
					from kucun_kdt_view 
					where Sty_no like '[^a-zA-Z]%'
					group by Sty_no,Com_nm,Unt_pr having(sum(Com_qu))>@kucun_num --order by Sty_no desc
				) tmp 
				left join 
				(
					select StyleNo, max(UploadTime) uptime from kdt_upload_item 
					group by StyleNo
				) up
				on up.styleno=tmp.sty_no
				where tmp.row_num between ((@page_num-1)*10+1) and @page_num*10

				if @page_num=1 --获取总页数
					begin
						select count(*) from
						(
							select sty_no from kucun_kdt_view
							where Sty_no like '[^a-zA-Z]%'
							group by Sty_no,Com_nm,Unt_pr having(sum(Com_qu))>@kucun_num
						) tmp
					end
			end

			
		else --默认查询所有的
			begin
				select tmp.*,isnull(up.uptime,'') uptime from 
				(
					select row_number() over(order by Sty_no desc) row_num,sty_no,
					com_nm,CONVERT(decimal(10,2), sum(Com_qu)) kucun,
					convert(decimal(10,2),Unt_pr) unt_pr
					from kucun_kdt_view 
					where Sty_no like '[^a-zA-Z]%'
					group by Sty_no,Com_nm,Unt_pr --order by Sty_no desc
				) tmp 
				left join 
				(
					select StyleNo, max(UploadTime) uptime from kdt_upload_item 
					group by StyleNo
				) up
				on up.styleno=tmp.sty_no
				where tmp.row_num between ((@page_num-1)*10+1) and @page_num*10

				if @page_num=1 --获取总页数
					begin
						select count(*) from
						(
							select sty_no from kucun_kdt_view 
							where Sty_no like '[^a-zA-Z]%'
							group by Sty_no,Com_nm,Unt_pr
						) tmp
					end
			end

end

go
--获取sku详情
create proc kdt_style_detail_proc
(
	@style_no varchar(30)
)
as
	begin
		select tmp.*,up.uptime from
		(
			select k.Com_nm,k.Sty_no,k.Col_no,
			k.Col_dr,k.Siz_dr,Siz_no,k.Unt_pr,SUM(k.Com_qu) as Com_qu,siz_id
			from kucun_kdt_view k 
			where Sty_no=@style_no 
			group by k.Com_nm,k.Sty_no,k.Col_no,k.Col_dr,k.Siz_dr,k.Siz_no,k.Unt_pr,k.siz_id
		) tmp
		left join 
		(
			select StyleNo,ColNo,size, max(UploadTime) uptime from kdt_upload_item 
			group by StyleNo,ColNo,size
		) up on up.styleno=Sty_no and up.ColNo=Col_no and siz_dr=up.size order by tmp.siz_id
	end
go
