--口袋通使用的库存视图
create  view  kucun_kdt_view
as
	SELECT Com_nm,replace(Sty_no,'','') Sty_no,
	Col_no,Col_dr,Siz_dr,Unt_pr,vws003.Sto_n1 Com_qu 
	FROM eissy.dbo.vwS003 
	Where Del_bz<>'Y' and vws003.Sto_n1>0;
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
				select * from 
				(
					select row_number() over(order by Sty_no desc) row_num, sty_no,com_nm,CONVERT(decimal(10,2), sum(Com_qu)) kucun,
					convert(decimal(10,2),Unt_pr) unt_pr from kucun_kdt_view where
					Sty_no like '[^a-zA-Z]%' and Sty_no like @style_no+'%' 
					--and row_number() between ((@page_num-1)*10+1) and @page_num*10
					group by Sty_no,Com_nm,Unt_pr --order by Sty_no desc
				) tmp where tmp.row_num between ((@page_num-1)*10+1) and @page_num*10

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
				select * from 
				(
					select row_number() over(order by Sty_no desc) row_num,sty_no,com_nm,CONVERT(decimal(10,2), sum(Com_qu)) kucun,
					convert(decimal(10,2),Unt_pr) unt_pr from kucun_kdt_view where
					Sty_no like '[^a-zA-Z]%' and com_nm like @style_name+'%'
					--and row_number() between ((@page_num-1)*10+1) and @page_num*10
					group by Sty_no,Com_nm,Unt_pr-- order by Sty_no desc
				) tmp where tmp.row_num between ((@page_num-1)*10+1) and @page_num*10
				
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
				select * from 
				(	
					select row_number() over(order by Sty_no desc) row_num,sty_no,com_nm,CONVERT(decimal(10,2), sum(Com_qu)) kucun,
					convert(decimal(10,2),Unt_pr) unt_pr from kucun_kdt_view 
					where Sty_no like '[^a-zA-Z]%'
					--and row_number() between ((@page_num-1)*10+1) and @page_num*10
					group by Sty_no,Com_nm,Unt_pr having(sum(Com_qu))>@kucun_num --order by Sty_no desc
				) tmp where tmp.row_num between ((@page_num-1)*10+1) and @page_num*10

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
				select * from 
				(
					select row_number() over(order by Sty_no desc) row_num,sty_no,com_nm,CONVERT(decimal(10,2), sum(Com_qu)) kucun,
					convert(decimal(10,2),Unt_pr) unt_pr from kucun_kdt_view 
					where Sty_no like '[^a-zA-Z]%'
					--and row_number() between ((@page_num-1)*10+1) and @page_num*10
					group by Sty_no,Com_nm,Unt_pr --order by Sty_no desc
				) tmp where tmp.row_num between ((@page_num-1)*10+1) and @page_num*10

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


