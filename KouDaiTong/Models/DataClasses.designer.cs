﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace KouDaiTong.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="eissy")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void Insertkdt_upload_item(kdt_upload_item instance);
    partial void Updatekdt_upload_item(kdt_upload_item instance);
    partial void Deletekdt_upload_item(kdt_upload_item instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::KouDaiTong.Properties.Settings.Default.eissyConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<kucun_kdt_view> kucun_kdt_view
		{
			get
			{
				return this.GetTable<kucun_kdt_view>();
			}
		}
		
		public System.Data.Linq.Table<kdt_upload_item> kdt_upload_item
		{
			get
			{
				return this.GetTable<kdt_upload_item>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.kdt_style_kucun_proc")]
		public ISingleResult<kdt_style_kucun_procResult> kdt_style_kucun_proc([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string style_no, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string style_name, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(18,0)")] System.Nullable<decimal> kucun_num, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> flag, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> page_num)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), style_no, style_name, kucun_num, flag, page_num);
			return ((ISingleResult<kdt_style_kucun_procResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.kucun_kdt_view")]
	public partial class kucun_kdt_view
	{
		
		private string _Com_nm;
		
		private string _Sty_no;
		
		private string _Col_no;
		
		private string _Col_dr;
		
		private string _Siz_dr;
		
		private decimal _Unt_pr;
		
		private decimal _Com_qu;
		
		public kucun_kdt_view()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Com_nm", DbType="VarChar(100)")]
		public string Com_nm
		{
			get
			{
				return this._Com_nm;
			}
			set
			{
				if ((this._Com_nm != value))
				{
					this._Com_nm = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sty_no", DbType="VarChar(8000)")]
		public string Sty_no
		{
			get
			{
				return this._Sty_no;
			}
			set
			{
				if ((this._Sty_no != value))
				{
					this._Sty_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Col_no", DbType="VarChar(8) NOT NULL", CanBeNull=false)]
		public string Col_no
		{
			get
			{
				return this._Col_no;
			}
			set
			{
				if ((this._Col_no != value))
				{
					this._Col_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Col_dr", DbType="VarChar(100)")]
		public string Col_dr
		{
			get
			{
				return this._Col_dr;
			}
			set
			{
				if ((this._Col_dr != value))
				{
					this._Col_dr = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Siz_dr", DbType="VarChar(100)")]
		public string Siz_dr
		{
			get
			{
				return this._Siz_dr;
			}
			set
			{
				if ((this._Siz_dr != value))
				{
					this._Siz_dr = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Unt_pr", DbType="Decimal(18,8) NOT NULL")]
		public decimal Unt_pr
		{
			get
			{
				return this._Unt_pr;
			}
			set
			{
				if ((this._Unt_pr != value))
				{
					this._Unt_pr = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Com_qu", DbType="Decimal(18,8) NOT NULL")]
		public decimal Com_qu
		{
			get
			{
				return this._Com_qu;
			}
			set
			{
				if ((this._Com_qu != value))
				{
					this._Com_qu = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.kdt_upload_item")]
	public partial class kdt_upload_item : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _StyleNo;
		
		private string _ColNo;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnStyleNoChanging(string value);
    partial void OnStyleNoChanged();
    partial void OnColNoChanging(string value);
    partial void OnColNoChanged();
    #endregion
		
		public kdt_upload_item()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StyleNo", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string StyleNo
		{
			get
			{
				return this._StyleNo;
			}
			set
			{
				if ((this._StyleNo != value))
				{
					this.OnStyleNoChanging(value);
					this.SendPropertyChanging();
					this._StyleNo = value;
					this.SendPropertyChanged("StyleNo");
					this.OnStyleNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ColNo", DbType="VarChar(50)")]
		public string ColNo
		{
			get
			{
				return this._ColNo;
			}
			set
			{
				if ((this._ColNo != value))
				{
					this.OnColNoChanging(value);
					this.SendPropertyChanging();
					this._ColNo = value;
					this.SendPropertyChanged("ColNo");
					this.OnColNoChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class kdt_style_kucun_procResult
	{
		
		private System.Nullable<long> _row_num;
		
		private string _sty_no;
		
		private string _com_nm;
		
		private System.Nullable<decimal> _kucun;
		
		private System.Nullable<decimal> _unt_pr;
		
		public kdt_style_kucun_procResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_row_num", DbType="BigInt")]
		public System.Nullable<long> row_num
		{
			get
			{
				return this._row_num;
			}
			set
			{
				if ((this._row_num != value))
				{
					this._row_num = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sty_no", DbType="VarChar(8000)")]
		public string sty_no
		{
			get
			{
				return this._sty_no;
			}
			set
			{
				if ((this._sty_no != value))
				{
					this._sty_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_com_nm", DbType="VarChar(100)")]
		public string com_nm
		{
			get
			{
				return this._com_nm;
			}
			set
			{
				if ((this._com_nm != value))
				{
					this._com_nm = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kucun", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> kucun
		{
			get
			{
				return this._kucun;
			}
			set
			{
				if ((this._kucun != value))
				{
					this._kucun = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_unt_pr", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> unt_pr
		{
			get
			{
				return this._unt_pr;
			}
			set
			{
				if ((this._unt_pr != value))
				{
					this._unt_pr = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
