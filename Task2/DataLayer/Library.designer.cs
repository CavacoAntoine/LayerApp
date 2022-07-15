﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PT")]
	public partial class LibraryDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertaction(action instance);
    partial void Updateaction(action instance);
    partial void Deleteaction(action instance);
    partial void Insertuser(user instance);
    partial void Updateuser(user instance);
    partial void Deleteuser(user instance);
    partial void Insertcatalog(catalog instance);
    partial void Updatecatalog(catalog instance);
    partial void Deletecatalog(catalog instance);
    partial void Insertstate(state instance);
    partial void Updatestate(state instance);
    partial void Deletestate(state instance);
    #endregion
		
		public LibraryDataContext() : 
				base(global::DataLayer.Properties.Settings.Default.PTConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LibraryDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LibraryDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LibraryDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LibraryDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<action> actions
		{
			get
			{
				return this.GetTable<action>();
			}
		}
		
		public System.Data.Linq.Table<user> users
		{
			get
			{
				return this.GetTable<user>();
			}
		}
		
		public System.Data.Linq.Table<catalog> catalogs
		{
			get
			{
				return this.GetTable<catalog>();
			}
		}
		
		public System.Data.Linq.Table<state> states
		{
			get
			{
				return this.GetTable<state>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.actions")]
	public partial class action : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _action_id;
		
		private string _description;
		
		private int _state_id;
		
		private string _email;
		
		private EntityRef<user> _user;
		
		private EntityRef<state> _state;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onaction_idChanging(int value);
    partial void Onaction_idChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void Onstate_idChanging(int value);
    partial void Onstate_idChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    #endregion
		
		public action()
		{
			this._user = default(EntityRef<user>);
			this._state = default(EntityRef<state>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_action_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int action_id
		{
			get
			{
				return this._action_id;
			}
			set
			{
				if ((this._action_id != value))
				{
					this.Onaction_idChanging(value);
					this.SendPropertyChanging();
					this._action_id = value;
					this.SendPropertyChanged("action_id");
					this.Onaction_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state_id", DbType="Int NOT NULL")]
		public int state_id
		{
			get
			{
				return this._state_id;
			}
			set
			{
				if ((this._state_id != value))
				{
					if (this._state.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onstate_idChanging(value);
					this.SendPropertyChanging();
					this._state_id = value;
					this.SendPropertyChanged("state_id");
					this.Onstate_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					if (this._user.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_action", Storage="_user", ThisKey="email", OtherKey="email", IsForeignKey=true)]
		public user user
		{
			get
			{
				return this._user.Entity;
			}
			set
			{
				user previousValue = this._user.Entity;
				if (((previousValue != value) 
							|| (this._user.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._user.Entity = null;
						previousValue.actions.Remove(this);
					}
					this._user.Entity = value;
					if ((value != null))
					{
						value.actions.Add(this);
						this._email = value.email;
					}
					else
					{
						this._email = default(string);
					}
					this.SendPropertyChanged("user");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="state_action", Storage="_state", ThisKey="state_id", OtherKey="state_id", IsForeignKey=true)]
		public state state
		{
			get
			{
				return this._state.Entity;
			}
			set
			{
				state previousValue = this._state.Entity;
				if (((previousValue != value) 
							|| (this._state.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._state.Entity = null;
						previousValue.actions.Remove(this);
					}
					this._state.Entity = value;
					if ((value != null))
					{
						value.actions.Add(this);
						this._state_id = value.state_id;
					}
					else
					{
						this._state_id = default(int);
					}
					this.SendPropertyChanged("state");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.users")]
	public partial class user : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _email;
		
		private string _name;
		
		private string _surname;
		
		private EntitySet<action> _actions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnsurnameChanging(string value);
    partial void OnsurnameChanged();
    #endregion
		
		public user()
		{
			this._actions = new EntitySet<action>(new Action<action>(this.attach_actions), new Action<action>(this.detach_actions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(100) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this.OnsurnameChanging(value);
					this.SendPropertyChanging();
					this._surname = value;
					this.SendPropertyChanged("surname");
					this.OnsurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_action", Storage="_actions", ThisKey="email", OtherKey="email")]
		public EntitySet<action> actions
		{
			get
			{
				return this._actions;
			}
			set
			{
				this._actions.Assign(value);
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
		
		private void attach_actions(action entity)
		{
			this.SendPropertyChanging();
			entity.user = this;
		}
		
		private void detach_actions(action entity)
		{
			this.SendPropertyChanging();
			entity.user = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.catalogs")]
	public partial class catalog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _isbn;
		
		private string _author;
		
		private string _title;
		
		private EntitySet<state> _states;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnisbnChanging(int value);
    partial void OnisbnChanged();
    partial void OnauthorChanging(string value);
    partial void OnauthorChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    #endregion
		
		public catalog()
		{
			this._states = new EntitySet<state>(new Action<state>(this.attach_states), new Action<state>(this.detach_states));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isbn", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int isbn
		{
			get
			{
				return this._isbn;
			}
			set
			{
				if ((this._isbn != value))
				{
					this.OnisbnChanging(value);
					this.SendPropertyChanging();
					this._isbn = value;
					this.SendPropertyChanged("isbn");
					this.OnisbnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_author", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string author
		{
			get
			{
				return this._author;
			}
			set
			{
				if ((this._author != value))
				{
					this.OnauthorChanging(value);
					this.SendPropertyChanging();
					this._author = value;
					this.SendPropertyChanged("author");
					this.OnauthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="catalog_state", Storage="_states", ThisKey="isbn", OtherKey="isbn")]
		public EntitySet<state> states
		{
			get
			{
				return this._states;
			}
			set
			{
				this._states.Assign(value);
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
		
		private void attach_states(state entity)
		{
			this.SendPropertyChanging();
			entity.catalog = this;
		}
		
		private void detach_states(state entity)
		{
			this.SendPropertyChanging();
			entity.catalog = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.states")]
	public partial class state : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _state_id;
		
		private int _isbn;
		
		private char _available;
		
		private EntitySet<action> _actions;
		
		private EntityRef<catalog> _catalog;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onstate_idChanging(int value);
    partial void Onstate_idChanged();
    partial void OnisbnChanging(int value);
    partial void OnisbnChanged();
    partial void OnavailableChanging(char value);
    partial void OnavailableChanged();
    #endregion
		
		public state()
		{
			this._actions = new EntitySet<action>(new Action<action>(this.attach_actions), new Action<action>(this.detach_actions));
			this._catalog = default(EntityRef<catalog>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int state_id
		{
			get
			{
				return this._state_id;
			}
			set
			{
				if ((this._state_id != value))
				{
					this.Onstate_idChanging(value);
					this.SendPropertyChanging();
					this._state_id = value;
					this.SendPropertyChanged("state_id");
					this.Onstate_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isbn", DbType="Int NOT NULL")]
		public int isbn
		{
			get
			{
				return this._isbn;
			}
			set
			{
				if ((this._isbn != value))
				{
					if (this._catalog.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnisbnChanging(value);
					this.SendPropertyChanging();
					this._isbn = value;
					this.SendPropertyChanged("isbn");
					this.OnisbnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_available", DbType="Char(1) NOT NULL")]
		public char available
		{
			get
			{
				return this._available;
			}
			set
			{
				if ((this._available != value))
				{
					this.OnavailableChanging(value);
					this.SendPropertyChanging();
					this._available = value;
					this.SendPropertyChanged("available");
					this.OnavailableChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="state_action", Storage="_actions", ThisKey="state_id", OtherKey="state_id")]
		public EntitySet<action> actions
		{
			get
			{
				return this._actions;
			}
			set
			{
				this._actions.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="catalog_state", Storage="_catalog", ThisKey="isbn", OtherKey="isbn", IsForeignKey=true)]
		public catalog catalog
		{
			get
			{
				return this._catalog.Entity;
			}
			set
			{
				catalog previousValue = this._catalog.Entity;
				if (((previousValue != value) 
							|| (this._catalog.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._catalog.Entity = null;
						previousValue.states.Remove(this);
					}
					this._catalog.Entity = value;
					if ((value != null))
					{
						value.states.Add(this);
						this._isbn = value.isbn;
					}
					else
					{
						this._isbn = default(int);
					}
					this.SendPropertyChanged("catalog");
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
		
		private void attach_actions(action entity)
		{
			this.SendPropertyChanging();
			entity.state = this;
		}
		
		private void detach_actions(action entity)
		{
			this.SendPropertyChanging();
			entity.state = null;
		}
	}
}
#pragma warning restore 1591
