using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Security.Claims;
//using System.Text;

//namespace MyChatWebApp.Models
//{
//    public abstract class PermissionSetting
//    {

//        /// <summary>
//        /// Unique name of the permission.
//        /// </summary>
//        [Required]
//        public virtual string Name { get; set; }

//        /// <summary>
//        /// Is this role granted for this permission.
//        /// Default value: true.
//        /// </summary>
//        public virtual bool IsGranted { get; set; }

//        /// <summary>
//        /// Creates a new <see cref="PermissionSetting"/> entity.
//        /// </summary>
//        protected PermissionSetting()
//        {
//            IsGranted = true;
//        }
//    }

//    public class RolePermissionSetting : PermissionSetting
//    {
//        /// <summary>
//        /// Role id.
//        /// </summary>
//        public virtual int RoleId { get; set; }
//    }
//    public class Role
//    {
//        public virtual string NormalizedName { get; set; }
//        [Required]
//        public virtual string Name { get; set; }

//        /// <summary>
//        /// Display name of this role.
//        /// </summary>
//        [Required]
//        public virtual string DisplayName { get; set; }

//        /// <summary>
//        /// Is this a static role?
//        /// Static roles can not be deleted, can not change their name.
//        /// They can be used programmatically.
//        /// </summary>
//        public virtual bool IsStatic { get; set; }

//        /// <summary>
//        /// Is this role will be assigned to new users as default?
//        /// </summary>
//        public virtual bool IsDefault { get; set; }

//        /// <summary>
//        /// List of permissions of the role.
//        /// </summary>
//        [ForeignKey("RoleId")]
//        public virtual ICollection<RolePermissionSetting> Permissions { get; set; }

//        public Role()
//        {

//        }

//        protected Role(string displayName)
//            : this()
//        {
//            DisplayName = displayName;
//        }

//        protected Role(string name, string displayName)
//            : this(displayName)
//        {
//            Name = name;
//        }

//    }
//    public class UserPermissionSetting : PermissionSetting
//    {
//        /// <summary>
//        /// User id.
//        /// </summary>
//        public virtual long UserId { get; set; }
//    }
//    public class UserClaim
//    {


//        public virtual long UserId { get; set; }

//        public virtual string ClaimType { get; set; }

//        public virtual string ClaimValue { get; set; }

//        public UserClaim()
//        {

//        }

//        public UserClaim(User user, Claim claim)
//        {
//            ClaimType = claim.Type;
//            ClaimValue = claim.Value;
//        }
//    }
//    public class UserRole
//    {

//        /// <summary>
//        /// User id.
//        /// </summary>
//        public virtual long UserId { get; set; }

//        /// <summary>
//        /// Role id.
//        /// </summary>
//        public virtual int RoleId { get; set; }

//        /// <summary>
//        /// Creates a new <see cref="UserRole"/> object.
//        /// </summary>
//        public UserRole()
//        {

//        }

//        /// <summary>
//        /// Creates a new <see cref="UserRole"/> object.
//        /// </summary>
//        /// <param name="tenantId">Tenant id</param>
//        /// <param name="userId">User id</param>
//        /// <param name="roleId">Role id</param>
//        public UserRole(int? tenantId, long userId, int roleId)
//        {
//            UserId = userId;
//            RoleId = roleId;
//        }
//    }

//    public class User
//    {
//        public virtual long Id { get; set; }

//        public virtual string NormalizedUserName { get; set; }
//        public virtual string UserName { get; set; }

//        /// <summary>
//        /// Tenant Id of this user.
//        /// </summary>
//        public virtual int? TenantId { get; set; }

//        /// <summary>
//        /// Email address of the user.
//        /// Email address must be unique for it's tenant.
//        /// </summary>
//        [Required]
//        public virtual string EmailAddress { get; set; }

//        /// <summary>
//        /// Name of the user.
//        /// </summary>
//        [Required]
//        public virtual string Name { get; set; }

//        /// <summary>
//        /// Surname of the user.
//        /// </summary>
//        [Required]
//        public virtual string Surname { get; set; }

//        /// <summary>
//        /// Return full name (Name Surname )
//        /// </summary>
//        [NotMapped]
//        public virtual string FullName { get { return this.Name + " " + this.Surname; } }

//        /// <summary>
//        /// Password of the user.
//        /// </summary>
//        [Required]
//        public virtual string Password { get; set; }

//        /// <summary>
//        /// Confirmation code for email.
//        /// </summary>

//        /// <summary>
//        /// Reset code for password.
//        /// It's not valid if it's null.
//        /// It's for one usage and must be set to null after reset.
//        /// </summary>

//        /// <summary>
//        /// Lockout end date.
//        /// </summary>
//        public virtual DateTime? LockoutEndDateUtc { get; set; }

//        /// <summary>
//        /// Gets or sets the access failed count.
//        /// </summary>
//        public virtual int AccessFailedCount { get; set; }

//        /// <summary>
//        /// Gets or sets the lockout enabled.
//        /// </summary>
//        public virtual bool IsLockoutEnabled { get; set; }

//        /// <summary>
//        /// Gets or sets the phone number.
//        /// </summary>
//        public virtual string PhoneNumber { get; set; }

//        /// <summary>
//        /// Is the <see cref="PhoneNumber"/> confirmed.
//        public virtual string SecurityStamp { get; set; }


//        /// <summary>
//        /// Roles of this user.
//        /// </summary>
//        [ForeignKey("UserId")]
//        public virtual ICollection<UserRole> Roles { get; set; }

//        /// <summary>
//        /// Claims of this user.
//        /// </summary>
//        [ForeignKey("UserId")]
//        public virtual ICollection<UserClaim> Claims { get; set; }

//        /// <summary>
//        /// Permission definitions for this user.
//        /// </summary>
//        [ForeignKey("UserId")]
//        public virtual ICollection<UserPermissionSetting> Permissions { get; set; }

//        /// <summary>
//        /// Settings for this user.
//        /// </summary>
//        [ForeignKey("UserId")]
//        //public virtual ICollection<Setting> Settings { get; set; }

//        /// <summary>
//        /// Is the <see cref="AbpUserBase.EmailAddress"/> confirmed.
//        /// </summary>
//        public virtual bool IsEmailConfirmed { get; set; }

//        /// <summary>
//        /// Is this user active?
//        /// If as user is not active, he/she can not use the application.
//        /// </summary>
//        public virtual bool IsActive { get; set; }

//    }
//    public class PermissionGrantInfo
//    {
//        /// <summary>
//        /// Name of the permission.
//        /// </summary>
//        public string Name { get; private set; }

//        /// <summary>
//        /// Is this permission granted Prohibited?
//        /// </summary>
//        public bool IsGranted { get; private set; }

//        /// <summary>
//        /// Creates a new instance of <see cref="PermissionGrantInfo"/>.
//        /// </summary>
//        /// <param name="name"></param>
//        /// <param name="isGranted"></param>
//        public PermissionGrantInfo(string name, bool isGranted)
//        {
//            Name = name;
//            IsGranted = isGranted;
//        }
//    }
//    public interface IUserPermissionStore<TUser>
//    {
//        /// <summary>
//        /// Adds a permission grant setting to a user.
//        /// </summary>
//        /// <param name="user">User</param>
//        /// <param name="permissionGrant">Permission grant setting info</param>
//        Task AddPermissionAsync(TUser user, PermissionGrantInfo permissionGrant);

//        /// <summary>
//        /// Adds a permission grant setting to a user.
//        /// </summary>
//        /// <param name="user">User</param>
//        /// <param name="permissionGrant">Permission grant setting info</param>
//        void AddPermission(TUser user, PermissionGrantInfo permissionGrant);

//        /// <summary>
//        /// Removes a permission grant setting from a user.
//        /// </summary>
//        /// <param name="user">User</param>
//        /// <param name="permissionGrant">Permission grant setting info</param>
//        Task RemovePermissionAsync(TUser user, PermissionGrantInfo permissionGrant);

//        /// <summary>
//        /// Removes a permission grant setting from a user.
//        /// </summary>
//        /// <param name="user">User</param>
//        /// <param name="permissionGrant">Permission grant setting info</param>
//        void RemovePermission(TUser user, PermissionGrantInfo permissionGrant);

//        /// <summary>
//        /// Gets permission grant setting informations for a user.
//        /// </summary>
//        /// <param name="userId">User id</param>
//        /// <returns>List of permission setting informations</returns>
//        Task<IList<PermissionGrantInfo>> GetPermissionsAsync(long userId);

//        /// <summary>
//        /// Gets permission grant setting informations for a user.
//        /// </summary>
//        /// <param name="userId">User id</param>
//        /// <returns>List of permission setting informations</returns>
//        IList<PermissionGrantInfo> GetPermissions(long userId);

//        /// <summary>
//        /// Checks whether a role has a permission grant setting info.
//        /// </summary>
//        /// <param name="userId">User id</param>
//        /// <param name="permissionGrant">Permission grant setting info</param>
//        /// <returns></returns>
//        Task<bool> HasPermissionAsync(long userId, PermissionGrantInfo permissionGrant);

//        /// <summary>
//        /// Checks whether a role has a permission grant setting info.
//        /// </summary>
//        /// <param name="userId">User id</param>
//        /// <param name="permissionGrant">Permission grant setting info</param>
//        /// <returns></returns>
//        bool HasPermission(long userId, PermissionGrantInfo permissionGrant);

//        /// <summary>
//        /// Deleted all permission settings for a role.
//        /// </summary>
//        /// <param name="user">User</param>
//        Task RemoveAllPermissionSettingsAsync(TUser user);

//        /// <summary>
//        /// Deleted all permission settings for a role.
//        /// </summary>
//        /// <param name="user">User</param>
//        void RemoveAllPermissionSettings(TUser user);
//    }
//    public abstract class AbpUserManager<TRole, TUser>
//    {
//        protected IUserPermissionStore<TUser> UserPermissionStore
//        {
//            get
//            {
//                throw new Exception("Store is not IUserPermissionStore");
//            }
//        }


//        /// <summary>
//        /// Returns a flag indicating whether the specified <paramref name="user"/> is a member of the given named role.
//        /// </summary>
//        /// <param name="user">The user whose role membership should be checked.</param>
//        /// <param name="role">The name of the role to be checked.</param>
//        /// <returns>
//        /// The <see cref="Task"/> that represents the asynchronous operation, containing a flag indicating whether the specified <paramref name="user"/> is
//        /// a member of the named role.
//        /// </returns>
//        public virtual async Task<bool> IsInRoleAsync(TUser user, string role)
//        {
//            return false;
//        }

//        /// <summary>
//        /// Check whether a user is granted for a permission.
//        /// </summary>
//        /// <param name="userId">User id</param>
//        /// <param name="permissionName">Permission name</param>
//        public virtual async Task<bool> IsGrantedAsync(long userId, string permissionName)
//        {
//            return false;

//            //return await IsGrantedAsync(
//            //    userId,
//            //    _permissionManager.GetPermission(permissionName)
//            //);
//        }

//        /// <summary>
//        /// Check whether a user is granted for a permission.
//        /// </summary>
//        /// <param name="userId">User id</param>
//        /// <param name="permissionName">Permission name</param>
//        public virtual bool IsGranted(long userId, string permissionName)
//        {
//            //return IsGranted(
//            //    userId,
//            //    _permissionManager.GetPermission(permissionName)
//            //);
//            return false;
//        }

//        /// <summary>
//        /// Check whether a user is granted for a permission.
//        /// </summary>
//        /// <param name="userId">User id</param>
//        /// <param name="permission">Permission</param>
//        public virtual async Task<bool> IsGrantedAsync(long userId, Permission permission)
//        {
//            //Check for multi-tenancy side

//            //    if (!await permission.FeatureDependency.IsSatisfiedAsync(FeatureDependencyContext))
//            //    {
//            //        return false;
//            //    }

//            ////Get cached user permissions
//            //var cacheItem = await GetUserPermissionCacheItemAsync(userId);
//            //if (cacheItem == null)
//            //{
//            //    return false;
//            //}

//            ////Check for user-specific value
//            //if (cacheItem.GrantedPermissions.Contains(permission.Name))
//            //{
//            //    return true;
//            //}

//            //if (cacheItem.ProhibitedPermissions.Contains(permission.Name))
//            //{
//            //    return false;
//            //}

//            ////Check for roles
//            //foreach (var roleId in cacheItem.RoleIds)
//            //{
//            //    if (await RoleManager.IsGrantedAsync(roleId, permission))
//            //    {
//            //        return true;
//            //    }
//            //}

//            return false;
//        }

//        /// <summary>
//        /// Check whether a user is granted for a permission.
//        /// </summary>
//        /// <param name="userId">User id</param>
//        /// <param name="permission">Permission</param>
//        public virtual bool IsGranted(long userId, Permission permission)
//        {
//            //Check for multi-tenancy side

//            ////Check for depended features
//            //if (permission.FeatureDependency != null && GetCurrentMultiTenancySide() == MultiTenancySides.Tenant)
//            //{
//            //    FeatureDependencyContext.TenantId = GetCurrentTenantId();

//            //    if (!permission.FeatureDependency.IsSatisfied(FeatureDependencyContext))
//            //    {
//            //        return false;
//            //    }
//            //}

//            ////Get cached user permissions
//            //var cacheItem = GetUserPermissionCacheItem(userId);
//            //if (cacheItem == null)
//            //{
//            //    return false;
//            //}

//            ////Check for user-specific value
//            //if (cacheItem.GrantedPermissions.Contains(permission.Name))
//            //{
//            //    return true;
//            //}

//            //if (cacheItem.ProhibitedPermissions.Contains(permission.Name))
//            //{
//            //    return false;
//            //}

//            ////Check for roles
//            //foreach (var roleId in cacheItem.RoleIds)
//            //{
//            //    if (RoleManager.IsGranted(roleId, permission))
//            //    {
//            //        return true;
//            //    }
//            //}

//            return false;
//        }


//        //private UserPermissionCacheItem GetUserPermissionCacheItem(long userId)
//        //{
//        //    var cacheKey = userId + "@" + (GetCurrentTenantId() ?? 0);
//        //    return _cacheManager.GetUserPermissionCache().Get(cacheKey, () =>
//        //    {
//        //        var user = AbpStore.FindById(userId);
//        //        if (user == null)
//        //        {
//        //            return null;
//        //        }

//        //        var newCacheItem = new UserPermissionCacheItem(userId);

//        //        foreach (var roleName in AbpStore.GetRoles(userId))
//        //        {
//        //            newCacheItem.RoleIds.Add((RoleManager.GetRoleByName(roleName)).Id);
//        //        }

//        //        foreach (var permissionInfo in UserPermissionStore.GetPermissions(userId))
//        //        {
//        //            if (permissionInfo.IsGranted)
//        //            {
//        //                newCacheItem.GrantedPermissions.Add(permissionInfo.Name);
//        //            }
//        //            else
//        //            {
//        //                newCacheItem.ProhibitedPermissions.Add(permissionInfo.Name);
//        //            }
//        //        }

//        //        return newCacheItem;
//        //    });
//        //}

//    }
//    public class Permission
//    {
//        /// <summary>
//        /// Parent of this permission if one exists.
//        /// If set, this permission can be granted only if parent is granted.
//        /// </summary>
//        public Permission Parent { get; private set; }

//        /// <summary>
//        /// Unique name of the permission.
//        /// This is the key name to grant permissions.
//        /// </summary>
//        public string Name { get; }

//        /// <summary>
//        /// Display name of the permission.
//        /// This can be used to show permission to the user.
//        /// </summary>
//        public String DisplayName { get; set; }

//        /// <summary>
//        /// A brief description for this permission.
//        /// </summary>
//        public String Description { get; set; }


//        /// <summary>
//        /// Custom Properties. Use this to add your own properties to permission.
//        /// <para>You can use this with indexer like Permission["mykey"]=data; </para>
//        /// <para>object mydata=Permission["mykey"]; </para>
//        /// </summary>
//        public Dictionary<string, object> Properties { get; }

//        /// <summary>
//        /// Shortcut of Properties dictionary
//        /// </summary>
//        public object this[string key]
//        {
//            get => !Properties.ContainsKey(key) ? null : Properties[key];
//            set
//            {
//                Properties[key] = value;
//            }
//        }
//        /// <summary>
//        /// List of child permissions. A child permission can be granted only if parent is granted.
//        /// </summary>
//        public IReadOnlyList<Permission> Children => _children.ToImmutableList();
//        private readonly List<Permission> _children;

//        /// <summary>
//        /// Creates a new Permission.
//        /// </summary>
//        /// <param name="name">Unique name of the permission</param>
//        /// <param name="displayName">Display name of the permission</param>
//        /// <param name="description">A brief description for this permission</param>
//        /// <param name="multiTenancySides">Which side can use this permission</param>
//        /// <param name="featureDependency">Depended feature(s) of this permission</param>
//        /// <param name="properties">Custom Properties. Use this to add your own properties to permission.</param>
//        public Permission(
//            string name,
//            String displayName = null,
//            String description = null,
//            Dictionary<string, object> properties = null)
//        {
//            if (name == null)
//            {
//                throw new ArgumentNullException("name");
//            }

//            Name = name;
//            DisplayName = displayName;
//            Description = description;
//            Properties = properties ?? new Dictionary<string, object>();

//            _children = new List<Permission>();
//        }

//        /// <summary>
//        /// Adds a child permission.
//        /// A child permission can be granted only if parent is granted.
//        /// </summary>
//        /// <returns>Returns newly created child permission</returns>
//        public Permission CreateChildPermission(
//            string name,
//            String displayName = null,
//            String description = null,
//            Dictionary<string, object> properties = null)
//        {
//            var permission = new Permission(name, displayName, description, properties) { Parent = this };
//            _children.Add(permission);
//            return permission;
//        }

//        public void RemoveChildPermission(string name)
//        {
//            _children.RemoveAll(p => p.Name == name);
//        }

//        public override string ToString()
//        {
//            return string.Format("[Permission: {0}]", Name);
//        }
//    }

//    public class AppPermissionChecker : PermissionChecker<Role, User>
//    {
//        public AppPermissionChecker(AbpUserManager<Role, User> userManager) : base(userManager)
//        {
//        }
//    }
//    /// <summary>
//    /// Application should inherit this class to implement <see cref="IPermissionChecker"/>.
//    /// </summary>
//    /// <typeparam name="TRole"></typeparam>
//    /// <typeparam name="TUser"></typeparam>
//    public abstract class PermissionChecker<TRole, TUser> : IPermissionChecker
//    {
//        private readonly AbpUserManager<TRole, TUser> _userManager;

//        /// <summary>
//        /// Constructor.
//        /// </summary>
//        protected PermissionChecker(AbpUserManager<TRole, TUser> userManager)
//        {
//            _userManager = userManager;

//        }

//        public virtual async Task<bool> IsGrantedAsync(string permissionName)
//        {
//            return AbpSession.UserId.HasValue &&
//                   await _userManager.IsGrantedAsync(AbpSession.UserId.Value, permissionName);
//        }

//        public virtual bool IsGranted(string permissionName)
//        {
//            return AbpSession.UserId.HasValue && _userManager.IsGranted(AbpSession.UserId.Value, permissionName);
//        }

//        public virtual async Task<bool> IsGrantedAsync(long userId, string permissionName)
//        {
//            return await _userManager.IsGrantedAsync(userId, permissionName);
//        }

//        public virtual bool IsGranted(long userId, string permissionName)
//        {
//            return _userManager.IsGranted(userId, permissionName);
//        }

//        public virtual async Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
//        {
//            return await UnitOfWorkManager.WithUnitOfWorkAsync(async () =>
//            {
//                if (CurrentUnitOfWorkProvider == null || CurrentUnitOfWorkProvider.Current == null)
//                {
//                    return await IsGrantedAsync(user.UserId, permissionName);
//                }

//                using (CurrentUnitOfWorkProvider.Current.SetTenantId(user.TenantId))
//                {
//                    return await _userManager.IsGrantedAsync(user.UserId, permissionName);
//                }
//            });
//        }

//        public virtual bool IsGranted(UserIdentifier user, string permissionName)
//        {
//            return UnitOfWorkManager.WithUnitOfWork(() =>
//            {
//                if (CurrentUnitOfWorkProvider == null || CurrentUnitOfWorkProvider.Current == null)
//                {
//                    return IsGranted(user.UserId, permissionName);
//                }

//                using (CurrentUnitOfWorkProvider.Current.SetTenantId(user.TenantId))
//                {
//                    return _userManager.IsGranted(user.UserId, permissionName);
//                }
//            });
//        }
//    }
//    public interface IPermissionChecker
//    {
//        /// <summary>
//        /// Checks if current user is granted for a permission.
//        /// </summary>
//        /// <param name="permissionName">Name of the permission</param>
//        Task<bool> IsGrantedAsync(string permissionName);

//        /// <summary>
//        /// Checks if current user is granted for a permission.
//        /// </summary>
//        /// <param name="permissionName">Name of the permission</param>
//        bool IsGranted(string permissionName);

//        /// <summary>
//        /// Checks if a user is granted for a permission.
//        /// </summary>
//        /// <param name="user">User to check</param>
//        /// <param name="permissionName">Name of the permission</param>
//        Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName);

//        /// <summary>
//        /// Checks if a user is granted for a permission.
//        /// </summary>
//        /// <param name="user">User to check</param>
//        /// <param name="permissionName">Name of the permission</param>
//        bool IsGranted(UserIdentifier user, string permissionName);
//    }
//    public interface IUserIdentifier
//    {
//        /// <summary>
//        /// Tenant Id. Can be null for host users.
//        /// </summary>
//        int? TenantId { get; }

//        /// <summary>
//        /// Id of the user.
//        /// </summary>
//        long UserId { get; }
//    }
//    /// <summary>
//    /// Used to identify a user.
//    /// </summary>
//    [Serializable]
//    public class UserIdentifier : IUserIdentifier
//    {
//        /// <summary>
//        /// Tenant Id of the user.
//        /// Can be null for host users in a multi tenant application.
//        /// </summary>
//        public int? TenantId { get; protected set; }

//        /// <summary>
//        /// Id of the user.
//        /// </summary>
//        public long UserId { get; protected set; }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="UserIdentifier"/> class.
//        /// </summary>
//        protected UserIdentifier()
//        {

//        }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="UserIdentifier"/> class.
//        /// </summary>
//        /// <param name="tenantId">Tenant Id of the user.</param>
//        /// <param name="userId">Id of the user.</param>
//        public UserIdentifier(long userId)
//        {
//            UserId = userId;
//        }

//        /// <summary>
//        /// Parses given string and creates a new <see cref="UserIdentifier"/> object.
//        /// </summary>
//        /// <param name="userIdentifierString">
//        /// Should be formatted one of the followings:
//        /// 
//        /// - "userId@tenantId". Ex: "42@3" (for tenant users).
//        /// - "userId". Ex: 1 (for host users)
//        /// </param>
//        public static UserIdentifier Parse(string userIdentifierString)
//        {

//            var splitted = userIdentifierString.Split('@');
//            if (splitted.Length == 1)
//            {
//                return new UserIdentifier(null, splitted[0].To<long>());

//            }

//            if (splitted.Length == 2)
//            {
//                return new UserIdentifier(splitted[1].To<int>(), splitted[0].To<long>());
//            }

//            throw new ArgumentException("userAtTenant is not properly formatted", nameof(userIdentifierString));
//        }

//        /// <summary>
//        /// Creates a string represents this <see cref="UserIdentifier"/> instance.
//        /// Formatted one of the followings:
//        /// 
//        /// - "userId@tenantId". Ex: "42@3" (for tenant users).
//        /// - "userId". Ex: 1 (for host users)
//        /// 
//        /// Returning string can be used in <see cref="Parse"/> method to re-create identical <see cref="UserIdentifier"/> object.
//        /// </summary>
//        public string ToUserIdentifierString()
//        {
//            if (TenantId == null)
//            {
//                return UserId.ToString();
//            }

//            return UserId + "@" + TenantId;
//        }


//    }
//    /// <summary>
//    /// Permission dependency context.
//    /// </summary>
//    public interface IPermissionDependencyContext
//    {
//        /// <summary>
//        /// The user which requires permission. Can be null if no user.
//        /// </summary>
//        UserIdentifier User { get; }


//        /// <summary>
//        /// Gets the <see cref="IFeatureChecker"/>.
//        /// </summary>
//        /// <value>
//        /// The feature checker.
//        /// </value>
//        IPermissionChecker PermissionChecker { get; }
//    }

//    /// <summary>
//    /// Defines interface to check a dependency.
//    /// </summary>
//    public interface IPermissionDependency
//    {
//        /// <summary>
//        /// Checks if permission dependency is satisfied.
//        /// </summary>
//        /// <param name="context">Context.</param>
//        Task<bool> IsSatisfiedAsync(IPermissionDependencyContext context);

//        /// <summary>
//        /// Checks if permission dependency is satisfied.
//        /// </summary>
//        /// <param name="context">Context.</param>
//        bool IsSatisfied(IPermissionDependencyContext context);
//    }
//    public class SimplePermissionDependency : IPermissionDependency
//    {
//        /// <summary>
//        /// A list of permissions to be checked if they are granted.
//        /// </summary>
//        public string[] Permissions { get; set; }

//        /// <summary>
//        /// If this property is set to true, all of the <see cref="Permissions"/> must be granted.
//        /// If it's false, at least one of the <see cref="Permissions"/> must be granted.
//        /// Default: false.
//        /// </summary>
//        public bool RequiresAll { get; set; }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="SimplePermissionDependency"/> class.
//        /// </summary>
//        /// <param name="permissions">The permissions.</param>
//        public SimplePermissionDependency(params string[] permissions)
//        {
//            Permissions = permissions;
//        }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="SimplePermissionDependency"/> class.
//        /// </summary>
//        /// <param name="requiresAll">
//        /// If this is set to true, all of the <see cref="Permissions"/> must be granted.
//        /// If it's false, at least one of the <see cref="Permissions"/> must be granted.
//        /// </param>
//        /// <param name="permissions">The permissions.</param>
//        public SimplePermissionDependency(bool requiresAll, params string[] permissions)
//            : this(permissions)
//        {
//            RequiresAll = requiresAll;
//        }

//        /// <inheritdoc/>
//        public Task<bool> IsSatisfiedAsync(IPermissionDependencyContext context)
//        {
//            return context.User != null
//                ? context.PermissionChecker.IsGrantedAsync(context.User, RequiresAll, Permissions)
//                : context.PermissionChecker.IsGrantedAsync(RequiresAll, Permissions);
//        }

//        /// <inheritdoc/>
//        public bool IsSatisfied(IPermissionDependencyContext context)
//        {
//            return context.User != null
//                ? context.PermissionChecker.IsGranted(context.User, RequiresAll, Permissions)
//                : context.PermissionChecker.IsGranted(RequiresAll, Permissions);
//        }
//    }

//    /// <summary>
//    /// Declares common interface for classes those have menu items.
//    /// </summary>
//    public interface IHasMenuItemDefinitions
//    {
//        /// <summary>
//        /// List of menu items.
//        /// </summary>
//        List<MenuItemDefinition> Items { get; }
//    }
//    public class MenuItemDefinition : IHasMenuItemDefinitions
//    {
//        /// <summary>
//        /// Unique name of the menu item in the application. 
//        /// Can be used to find this menu item later.
//        /// </summary>
//        public string Name { get; }

//        /// <summary>
//        /// Display name of the menu item. Required.
//        /// </summary>
//        public string DisplayName { get; set; }

//        /// <summary>
//        /// The Display order of the menu. Optional.
//        /// </summary>
//        public int Order { get; set; }

//        /// <summary>
//        /// Icon of the menu item if exists. Optional.
//        /// </summary>
//        public string Icon { get; set; }

//        /// <summary>
//        /// The URL to navigate when this menu item is selected. Optional.
//        /// </summary>
//        public string Url { get; set; }

//        /// <summary>
//        /// A permission dependency. Only users that can satisfy this permission dependency can see this menu item.
//        /// Optional.
//        /// </summary>
//        public IPermissionDependency PermissionDependency { get; set; }


//        /// <summary>
//        /// This can be set to true if only authenticated users should see this menu item.
//        /// </summary>
//        public bool RequiresAuthentication { get; set; }

//        /// <summary>
//        /// Returns true if this menu item has no child <see cref="Items"/>.
//        /// </summary>
//        public bool IsLeaf => Items.IsNullOrEmpty();

//        /// <summary>
//        /// Target of the menu item. Can be "_blank", "_self", "_parent", "_top" or a frame name.
//        /// </summary>
//        public string Target { get; set; }

//        /// <summary>
//        /// Can be used to store a custom object related to this menu item. Optional.
//        /// </summary>
//        public object CustomData { get; set; }

//        /// <summary>
//        /// Can be used to enable/disable a menu item.
//        /// </summary>
//        public bool IsEnabled { get; set; }

//        /// <summary>
//        /// Can be used to show/hide a menu item.
//        /// </summary>
//        public bool IsVisible { get; set; }

//        /// <summary>
//        /// Sub items of this menu item. Optional.
//        /// </summary>
//        public virtual List<MenuItemDefinition> Items { get; }

//        /// <param name="name"></param>
//        /// <param name="displayName"></param>
//        /// <param name="icon"></param>
//        /// <param name="url"></param>
//        /// <param name="requiresAuthentication"></param>
//        /// <param name="order"></param>
//        /// <param name="customData"></param>
//        /// <param name="featureDependency"></param>
//        /// <param name="target"></param>
//        /// <param name="isEnabled"></param>
//        /// <param name="isVisible"></param>
//        /// <param name="permissionDependency"></param>
//        public MenuItemDefinition(
//        string name,
//            String displayName,
//            string icon = null,
//            string url = null,
//            bool requiresAuthentication = false,
//            int order = 0,
//            object customData = null,
//            string target = null,
//            bool isEnabled = true,
//            bool isVisible = true,
//            IPermissionDependency permissionDependency = null)
//        {

//            Name = name;
//            DisplayName = displayName;
//            Icon = icon;
//            Url = url;
//            RequiresAuthentication = requiresAuthentication;
//            Order = order;
//            CustomData = customData;
//            Target = target;
//            IsEnabled = isEnabled;
//            IsVisible = isVisible;
//            PermissionDependency = permissionDependency;

//            Items = new List<MenuItemDefinition>();
//        }

//        /// <summary>
//        /// Adds a <see cref="MenuItemDefinition"/> to <see cref="Items"/>.
//        /// </summary>
//        /// <param name="menuItem"><see cref="MenuItemDefinition"/> to be added</param>
//        /// <returns>This <see cref="MenuItemDefinition"/> object</returns>
//        public MenuItemDefinition AddItem(MenuItemDefinition menuItem)
//        {
//            Items.Add(menuItem);
//            return this;
//        }

//        /// <summary>
//        /// Remove notification with given name
//        /// </summary>
//        /// <param name="name"></param>
//        public void RemoveItem(string name)
//        {
//            Items.RemoveAll(m => m.Name == name);
//        }
//    }
//    public class MenuDefinition : IHasMenuItemDefinitions
//    {
//        /// <summary>
//        /// Unique name of the menu in the application. Required.
//        /// </summary>
//        public string Name { get; private set; }

//        /// <summary>
//        /// Display name of the menu. Required.
//        /// </summary>
//        public String DisplayName { get; set; }

//        /// <summary>
//        /// Can be used to store a custom object related to this menu. Optional.
//        /// </summary>
//        public object CustomData { get; set; }

//        /// <summary>
//        /// Menu items (first level).
//        /// </summary>
//        public List<MenuItemDefinition> Items { get; set; }

//        /// <summary>
//        /// Creates a new <see cref="MenuDefinition"/> object.
//        /// </summary>
//        /// <param name="name">Unique name of the menu</param>
//        /// <param name="displayName">Display name of the menu</param>
//        /// <param name="customData">Can be used to store a custom object related to this menu.</param>
//        public MenuDefinition(string name, String displayName, object customData = null)
//        {
//            if (string.IsNullOrEmpty(name))
//            {
//                throw new ArgumentNullException("name", "Menu name can not be empty or null.");
//            }

//            if (displayName == null)
//            {
//                throw new ArgumentNullException("displayName", "Display name of the menu can not be null.");
//            }

//            Name = name;
//            DisplayName = displayName;
//            CustomData = customData;

//            Items = new List<MenuItemDefinition>();
//        }

//        /// <summary>
//        /// Adds a <see cref="MenuItemDefinition"/> to <see cref="Items"/>.
//        /// </summary>
//        /// <param name="menuItem"><see cref="MenuItemDefinition"/> to be added</param>
//        /// <returns>This <see cref="MenuDefinition"/> object</returns>
//        public MenuDefinition AddItem(MenuItemDefinition menuItem)
//        {
//            Items.Add(menuItem);
//            return this;
//        }

//        /// <summary>
//        /// Remove menu item with given name
//        /// </summary>
//        /// <param name="name"></param>
//        public void RemoveItem(string name)
//        {
//            Items.RemoveAll(m => m.Name == name);
//        }
//    }

//    /// <summary>
//    /// Manages navigation in the application.
//    /// </summary>
//    public interface INavigationManager
//    {
//        /// <summary>
//        /// All menus defined in the application.
//        /// </summary>
//        IDictionary<string, MenuDefinition> Menus { get; }

//        /// <summary>
//        /// Gets the main menu of the application.
//        /// A shortcut of <see cref="Menus"/>["MainMenu"].
//        /// </summary>
//        MenuDefinition MainMenu { get; }
//    }
//    public interface INavigationProviderContext
//    {
//        /// <summary>
//        /// Gets a reference to the menu manager.
//        /// </summary>
//        INavigationManager Manager { get; }
//    } /// <summary>
//      /// Used to manage navigation for users.
//      /// </summary>
//    public interface IUserNavigationManager
//    {
//        /// <summary>
//        /// Gets a menu specialized for given user.
//        /// </summary>
//        /// <param name="menuName">Unique name of the menu</param>
//        /// <param name="user">The user, or null for anonymous users</param>
//        Task<UserMenu> GetMenuAsync(string menuName, UserIdentifier user);

//        /// <summary>
//        /// Gets all menus specialized for given user.
//        /// </summary>
//        /// <param name="user">User id or null for anonymous users</param>
//        Task<IReadOnlyList<UserMenu>> GetMenusAsync(UserIdentifier user);
//    }
//    internal class NavigationManager : INavigationManager, ISingletonDependency
//    {
//        public IDictionary<string, MenuDefinition> Menus { get; private set; }

//        public MenuDefinition MainMenu
//        {
//            get { return Menus["MainMenu"]; }
//        }

//        private readonly IIocResolver _iocResolver;
//        private readonly INavigationConfiguration _configuration;

//        public NavigationManager(IIocResolver iocResolver, INavigationConfiguration configuration)
//        {
//            _iocResolver = iocResolver;
//            _configuration = configuration;

//            Menus = new Dictionary<string, MenuDefinition>
//                    {
//                        {"MainMenu", new MenuDefinition("MainMenu", new LocalizableString("MainMenu", AbpConsts.LocalizationSourceName))}
//                    };
//        }

//        public void Initialize()
//        {
//            var context = new NavigationProviderContext(this);

//            foreach (var providerType in _configuration.Providers)
//            {
//                using (var provider = _iocResolver.ResolveAsDisposable<NavigationProvider>(providerType))
//                {
//                    provider.Object.SetNavigation(context);
//                }
//            }
//        }
//    }

//    internal class NavigationProviderContext : INavigationProviderContext
//    {
//        public INavigationManager Manager { get; private set; }

//        public NavigationProviderContext(INavigationManager manager)
//        {
//            Manager = manager;
//        }
//    }

//    /// <summary>
//    /// This interface should be implemented by classes which change
//    /// navigation of the application.
//    /// </summary>
//    public abstract class NavigationProvider
//    {
//        /// <summary>
//        /// Used to set navigation.
//        /// </summary>
//        /// <param name="context">Navigation context</param>
//        public abstract void SetNavigation(INavigationProviderContext context);
//    }
//    public class MyNavigationProvider1 : NavigationProvider
//    {
//        public override void SetNavigation(INavigationProviderContext context)
//        {
//            context.Manager.MainMenu.AddItem(
//                new MenuItemDefinition(
//                    "Abp.Zero.Administration",
//                    new String("Administration"),
//                    "fa fa-asterisk",
//                    requiresAuthentication: true
//                    ).AddItem(
//                        new MenuItemDefinition(
//                            "Abp.Zero.Administration.User",
//                            new String("User management"),
//                            "fa fa-users",
//                            "#/admin/users",
//                            permissionDependency: new SimplePermissionDependency("Abp.Zero.UserManagement"),
//                            customData: "A simple test data"
//                            )
//                    ).AddItem(
//                        new MenuItemDefinition(
//                            "Abp.Zero.Administration.Role",
//                            new String("Role management"),
//                            "fa fa-star-o",
//                            "#/admin/roles",
//                            permissionDependency: new SimplePermissionDependency("Abp.Zero.RoleManagement")
//                            )
//                    )
//                );
//        }
//    }

//    public class UserMenu
//    {
//        /// <summary>
//        /// Unique name of the menu in the application. 
//        /// </summary>
//        public string Name { get; set; }

//        /// <summary>
//        /// Display name of the menu.
//        /// </summary>
//        public string DisplayName { get; set; }

//        /// <summary>
//        /// A custom object related to this menu item.
//        /// </summary>
//        public object CustomData { get; set; }

//        /// <summary>
//        /// Menu items (first level).
//        /// </summary>
//        public IList<UserMenuItem> Items { get; set; }

//        /// <summary>
//        /// Creates a new <see cref="UserMenu"/> object.
//        /// </summary>
//        public UserMenu()
//        {

//        }

//        /// <summary>
//        /// Creates a new <see cref="UserMenu"/> object from given <see cref="MenuDefinition"/>.
//        /// </summary>
//        internal UserMenu(MenuDefinition menuDefinition, ILocalizationContext localizationContext)
//        {
//            Name = menuDefinition.Name;
//            DisplayName = menuDefinition.DisplayName.Localize(localizationContext);
//            CustomData = menuDefinition.CustomData;
//            Items = new List<UserMenuItem>();
//        }
//    }
//    public class UserMenuItem
//    {
//        /// <summary>
//        /// Unique name of the menu item in the application. 
//        /// </summary>
//        public string Name { get; set; }

//        /// <summary>
//        /// Icon of the menu item if exists.
//        /// </summary>
//        public string Icon { get; set; }

//        /// <summary>
//        /// Display name of the menu item.
//        /// </summary>
//        public string DisplayName { get; set; }

//        /// <summary>
//        /// The Display order of the menu. Optional.
//        /// </summary>
//        public int Order { get; set; }

//        /// <summary>
//        /// The URL to navigate when this menu item is selected.
//        /// </summary>
//        public string Url { get; set; }

//        /// <summary>
//        /// A custom object related to this menu item.
//        /// </summary>
//        public object CustomData { get; set; }

//        /// <summary>
//        /// Target of the menu item. Can be "_blank", "_self", "_parent", "_top" or a frame name.
//        /// </summary>
//        public string Target { get; set; }

//        /// <summary>
//        /// Can be used to enable/disable a menu item.
//        /// </summary>
//        public bool IsEnabled { get; set; }

//        /// <summary>
//        /// Can be used to show/hide a menu item.
//        /// </summary>
//        public bool IsVisible { get; set; }

//        /// <summary>
//        /// Sub items of this menu item.
//        /// </summary>
//        public IList<UserMenuItem> Items { get; set; }

//        /// <summary>
//        /// Creates a new <see cref="UserMenuItem"/> object.
//        /// </summary>
//        public UserMenuItem()
//        {

//        }

//        /// <summary>
//        /// Creates a new <see cref="UserMenuItem"/> object from given <see cref="MenuItemDefinition"/>.
//        /// </summary>
//        public UserMenuItem(MenuItemDefinition menuItemDefinition, ILocalizationContext localizationContext)
//        {
//            Name = menuItemDefinition.Name;
//            Icon = menuItemDefinition.Icon;
//            DisplayName = menuItemDefinition.DisplayName.Localize(localizationContext);
//            Order = menuItemDefinition.Order;
//            Url = menuItemDefinition.Url;
//            CustomData = menuItemDefinition.CustomData;
//            Target = menuItemDefinition.Target;
//            IsEnabled = menuItemDefinition.IsEnabled;
//            IsVisible = menuItemDefinition.IsVisible;

//            Items = new List<UserMenuItem>();
//        }
//    }
//    internal class UserNavigationManager : IUserNavigationManager
//    {

//        private readonly INavigationManager _navigationManager;

//        public UserNavigationManager(
//            INavigationManager navigationManager
//            )
//        {
//            _navigationManager = navigationManager;
//        }

//        public async Task<UserMenu> GetMenuAsync(string menuName, UserIdentifier user)
//        {
//            var menuDefinition = _navigationManager.Menus.GetOrDefault(menuName);
//            if (menuDefinition == null)
//            {
//                throw new Exception("There is no menu with given name: " + menuName);
//            }

//            var userMenu = new UserMenu(menuDefinition, _localizationContext);
//            await FillUserMenuItems(user, menuDefinition.Items, userMenu.Items);
//            return userMenu;
//        }

//        public async Task<IReadOnlyList<UserMenu>> GetMenusAsync(UserIdentifier user)
//        {
//            var userMenus = new List<UserMenu>();

//            foreach (var menu in _navigationManager.Menus.Values)
//            {
//                userMenus.Add(await GetMenuAsync(menu.Name, user));
//            }

//            return userMenus;
//        }

//        private async Task<int> FillUserMenuItems(UserIdentifier user, IList<MenuItemDefinition> menuItemDefinitions, IList<UserMenuItem> userMenuItems)
//        {
//            //TODO: Can be optimized by re-using FeatureDependencyContext.

//            var addedMenuItemCount = 0;

//            using (var scope = _iocResolver.CreateScope())
//            {
//                var permissionDependencyContext = scope.Resolve<PermissionDependencyContext>();
//                permissionDependencyContext.User = user;

//                var featureDependencyContext = scope.Resolve<FeatureDependencyContext>();
//                featureDependencyContext.TenantId = user == null ? null : user.TenantId;

//                foreach (var menuItemDefinition in menuItemDefinitions)
//                {
//                    if (menuItemDefinition.RequiresAuthentication && user == null)
//                    {
//                        continue;
//                    }

//                    if (menuItemDefinition.PermissionDependency != null &&
//                        (user == null || !(await menuItemDefinition.PermissionDependency.IsSatisfiedAsync(permissionDependencyContext))))
//                    {
//                        continue;
//                    }

//                    if (menuItemDefinition.FeatureDependency != null &&
//                        (AbpSession.MultiTenancySide == MultiTenancySides.Tenant || (user != null && user.TenantId != null)) &&
//                        !(await menuItemDefinition.FeatureDependency.IsSatisfiedAsync(featureDependencyContext)))
//                    {
//                        continue;
//                    }

//                    var userMenuItem = new UserMenuItem(menuItemDefinition, _localizationContext);
//                    if (menuItemDefinition.IsLeaf || (await FillUserMenuItems(user, menuItemDefinition.Items, userMenuItem.Items)) > 0)
//                    {
//                        userMenuItems.Add(userMenuItem);
//                        ++addedMenuItemCount;
//                    }
//                }
//            }

//            return addedMenuItemCount;
//        }
//    }

//    public class AbpUserNavConfigDto
//    {
//        public Dictionary<string, UserMenu> Menus { get; set; }

//        protected virtual async Task<AbpUserNavConfigDto> GetUserNavConfig()
//        {
//            var userMenus = await UserNavigationManager.GetMenusAsync(new UserIdentifier(1));
//            return new AbpUserNavConfigDto
//            {
//                Menus = userMenus.ToDictionary(userMenu => userMenu.Name, userMenu => userMenu)
//            };
//        }
//    }
//    public interface INavigationScriptManager
//    {
//        /// <summary>
//        /// Used to generate navigation scripts.
//        /// </summary>
//        /// <returns></returns>
//        Task<string> GetScriptAsync();
//    }
//    internal class NavigationScriptManager : INavigationScriptManager
//    {

//        private readonly IUserNavigationManager _userNavigationManager;

//        public NavigationScriptManager(IUserNavigationManager userNavigationManager)
//        {
//            _userNavigationManager = userNavigationManager;
//        }

//        public async Task<string> GetScriptAsync()
//        {
//            var userMenus = await _userNavigationManager.GetMenusAsync(new UserIdentifier(1));

//            var script = new StringBuilder();
//            script.AppendLine("(function() {");

//            script.AppendLine("    abp.nav = {};");
//            script.AppendLine("    abp.nav.menus = {");

//            for (int i = 0; i < userMenus.Count; i++)
//            {
//                AppendMenu(script, userMenus[i]);
//                if (userMenus.Count - 1 > i)
//                {
//                    script.Append(" , ");
//                }
//            }

//            script.AppendLine("    };");

//            script.AppendLine("})();");

//            return script.ToString();
//        }

//        private static void AppendMenu(StringBuilder script, UserMenu menu)
//        {
//            script.AppendLine("        '" + (menu.Name) + "': {");

//            script.AppendLine("            name: '" + (menu.Name) + "',");

//            if (menu.DisplayName != null)
//            {
//                script.AppendLine("            displayName: '" + (menu.DisplayName) + "',");
//            }

//            script.Append("            items: ");

//            if (menu.Items.Count <= 0)
//            {
//                script.AppendLine("[]");
//            }
//            else
//            {
//                script.Append("[");
//                for (int i = 0; i < menu.Items.Count; i++)
//                {
//                    AppendMenuItem(16, script, menu.Items[i]);
//                    if (menu.Items.Count - 1 > i)
//                    {
//                        script.Append(" , ");
//                    }
//                }
//                script.AppendLine("]");
//            }

//            script.AppendLine("            }");
//        }

//        private static void AppendMenuItem(int indentLength, StringBuilder sb, UserMenuItem menuItem)
//        {
//            sb.AppendLine("{");

//            sb.AppendLine(new string(' ', indentLength + 4) + "name: '" + (menuItem.Name) + "',");
//            sb.AppendLine(new string(' ', indentLength + 4) + "order: " + menuItem.Order + ",");

//            if (!string.IsNullOrEmpty(menuItem.Icon))
//            {
//                sb.AppendLine(new string(' ', indentLength + 4) + "icon: '" + (menuItem.Icon) + "',");
//            }

//            if (!string.IsNullOrEmpty(menuItem.Url))
//            {
//                sb.AppendLine(new string(' ', indentLength + 4) + "url: '" + (menuItem.Url) + "',");
//            }

//            if (menuItem.DisplayName != null)
//            {
//                sb.AppendLine(new string(' ', indentLength + 4) + "displayName: '" + (menuItem.DisplayName) + "',");
//            }

//            if (menuItem.Target != null)
//            {
//                sb.AppendLine(new string(' ', indentLength + 4) + "target: '" + (menuItem.Target) + "',");
//            }

//            sb.AppendLine(new string(' ', indentLength + 4) + "isEnabled: " + menuItem.IsEnabled.ToString().ToLowerInvariant() + ",");
//            sb.AppendLine(new string(' ', indentLength + 4) + "isVisible: " + menuItem.IsVisible.ToString().ToLowerInvariant() + ",");

//            sb.Append(new string(' ', indentLength + 4) + "items: [");

//            for (int i = 0; i < menuItem.Items.Count; i++)
//            {
//                AppendMenuItem(24, sb, menuItem.Items[i]);
//                if (menuItem.Items.Count - 1 > i)
//                {
//                    sb.Append(" , ");
//                }
//            }

//            sb.AppendLine("]");

//            sb.Append(new string(' ', indentLength) + "}");
//        }
//    }

//}