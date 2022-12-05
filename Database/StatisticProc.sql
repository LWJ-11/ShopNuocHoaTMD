Create proc sp_Statistic
as 
Begin
	DECLARE @LastestNumberOfVisits int
	DECLARE @Count int 
	Select @Count = COUNT(*) From tb_Statistic
	if @Count is null set @Count = 0
	if @Count = 0
		Insert into tb_Statistic(TimeStat,NumberOfVisits)
		Values(GETDATE(),1)
	else
		Begin
			Declare @LastestTimeStat datetime
			Select @LastestNumberOfVisits = st.NumberOfVisits, @LastestTimeStat = st.TimeStat From tb_Statistic st
			Where st.Stat_Id = (Select MAX(st1.Stat_Id) From tb_Statistic st1)
			
			if @LastestNumberOfVisits is null set @LastestNumberOfVisits = 0
			if @LastestTimeStat is null set @LastestTimeStat = GETDATE()
			
			--Nếu chuyển sang ngày mới chưa (sau 12h đêm)
			--Nếu chưa chuyển sang ngày mới thì update
			if DAY(@LastestTimeStat) = DAY(GETDATE())
				Begin
					UPDATE tb_Statistic
					SET
					NumberOfVisits = @LastestNumberOfVisits + 1,
					TimeStat = GETDATE()
					Where Stat_Id = (Select MAX(st1.Stat_Id) From tb_Statistic st1)
				End
			--Nếu đã sang ngày mới rồi thì thêm một bản ghi mới
			else
				insert into tb_Statistic(TimeStat,NumberOfVisits)
				values(GETDATE(),1)
		End

	--Thống kê hom nay, hom qua, Tuan nay, Tuan truoc, Thang nay, Thang truoc
		DECLARE @today int
		Set @today = DATEPART(DW,GETDATE());
		Select @LastestNumberOfVisits = NumberOfVisits, @LastestTimeStat = TimeStat From tb_Statistic 
		Where Stat_Id = (Select MAX(Stat_Id) From tb_Statistic)

		--Số truy cập hôm qua
		DECLARE @numOfVisitsYesterday bigint
		Select @numOfVisitsYesterday = ISNULL(NumberOfVisits,0), @LastestTimeStat = TimeStat From tb_Statistic
		Where CONVERT(nvarchar(20), TimeStat,103) = CONVERT(nvarchar,GETDATE() - 1, 103)
		IF @numOfVisitsYesterday is null set @numOfVisitsYesterday = 0

		--Số truy cập đầu tuần này
		DECLARE @earlyThisWeek datetime
		SET @earlyThisWeek = DATEADD(wk,DATEDIFF(wk,6,GETDATE()),6)

		--Tính ngày đầu của tuần trước (Tính từ thời điểm 00:00)
		DECLARE @earlyLastWeek datetime
		SET @earlyLastWeek = CAST(CONVERT(nvarchar(30),DATEADD(dd, -(@today+6), GETDATE()),101) AS datetime)

		--Tính từ cuối tuần trước tính đến 24h ngày cuối tuần
		DECLARE @lastWeekend datetime
		SET @lastWeekend = CAST(CONVERT(nvarchar(30),DATEADD(dd, -@today, GETDATE()),101) + '23:59:59' AS datetime)

		--Số truy cập tuần này
		DECLARE @numOfVisitsThisWeek bigint
		SELECT @numOfVisitsThisWeek = ISNULL(sum(NumberOfVisits),0) From tb_Statistic
		Where TimeStat BETWEEN @earlyThisWeek AND GETDATE()

		--Số truy cập tuần trước
		DECLARE @numOfVisitsLastWeek bigint
		SELECT @numOfVisitsThisWeek = ISNULL(sum(NumberOfVisits),0) From tb_Statistic st
		Where st.TimeStat BETWEEN @earlyThisWeek AND @lastWeekend

		--Tính số truy cập tháng này
		DECLARE @numOfVisitsThisMonth bigint
		Select @numOfVisitsThisMonth = isnull(sum(NumberOfVisits),0) From tb_Statistic st
		Where MONTH(st.TimeStat) = MONTH(GETDATE())

		--Tính số truy cập tháng này
		DECLARE @numOfVisitsLastMonth bigint
		Select @numOfVisitsLastMonth = isnull(sum(NumberOfVisits),0) From tb_Statistic st
		Where MONTH(st.TimeStat) = MONTH(GETDATE()) - 1

		--Tính tổng số 
		DECLARE @total bigint
		SELECT @total = isnull(sum(NumberOfVisits),0) FROM tb_Statistic st

		SELECT @LastestNumberOfVisits as Today,
		@numOfVisitsYesterday as Yesterday,
		@numOfVisitsThisWeek as ThisWeek,
		@numOfVisitsLastWeek as LastWeek,
		@numOfVisitsThisMonth as ThisMonth,
		@numOfVisitsLastMonth as LastMonth,
		@total as Total

End