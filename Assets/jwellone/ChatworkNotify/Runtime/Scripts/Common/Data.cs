using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace jwellone.Chatwork
{
	[Serializable]
	public class Me : IResponseParam
	{
		public int account_id;
		public int room_id;
		public string name;
		public string chatwork_id;
		public int organization_id;
		public string organization_name;
		public string department;
		public string title;
		public string url;
		public string introduction;
		public string mail;
		public string tel_organization;
		public string tel_extension;
		public string tel_mobile;
		public string skype;
		public string facebook;
		public string twitter;
		public string avatar_image_url;
		public string login_mail;
	}

	[Serializable]
	public class MyStatus : IResponseParam
	{
		public int unread_room_num;
		public int mention_room_num;
		public int mytask_room_num;
		public int unread_num;
		public int mention_num;
		public int mytask_num;
	}

	[Serializable]
	public class RoomDetails : IResponseParam
	{
		public int room_id;
		public string name;
		public string type;
		public string role;
		public bool sticky;
		public int unread_num;
		public int mention_num;
		public int mytask_num;
		public int message_num;
		public int file_num;
		public int task_num;
		public string icon_path;
		public int last_update_time;
		public string description; // rooms/{room_id}用
	}

	[Serializable]
	public class Contact : IResponseParam
	{
		public int account_id;
		public int room_id;
		public string name;
		public string chatwork_id;
		public int organization_id;
		public string organization_name;
		public string department;
		public string avatar_image_url;
	}

	[Serializable]
	public class Account
	{
		public int account_id;
		public string name;
		public string avatar_image_url;
	}

	[Serializable]
	public class MessageContent : IResponseParam
	{
		public string message_id;
		public Account account;
		public string body;
		public int send_time;
		public int update_time;
	}

	[Serializable]
	public class IncomingRequest
	{
		public int request_id;
		public int account_id;
		public string message;
		public string name;
		public string chatwork_id;
		public int organization_id;
		public string organization_name;
		public string department;
		public string avatar_image_url;
	}

	[Serializable]
	public class Room
	{
		public int room_id;
		public string name;
		public string icon_path;
	}

	[Serializable]
	public class RoomUpdateInfo : IRequestParam
	{
		public string description;
		public string icon_preset;
		public string name;
	}

	[Serializable]
	public class RoomMemberAuthority : IRequestParam
	{
		public List<int> members_admin_ids = new List<int>();
		public List<int> members_member_ids = new List<int>();
		public List<int> members_readonly_ids = new List<int>();
	}

	[Serializable]
	public class NewRoomDetails : IRequestParam
	{
		public string description;
		public string icon_preset;
		public bool link;
		public string link_code;
		public bool link_need_acceptance;
		public List<int> members_admin_ids = new List<int>();
		public List<int> members_member_ids = new List<int>();
		public List<int> members_readonly_ids = new List<int>();
		public string name;
	}

	[Serializable]
	public class AssignedByAccount
	{
		public int account_id;
		public string name;
		public string avatar_image_url;
	}

	[Serializable]
	public class RoomMember
	{
		public int account_id;
		public string role;
		public string name;
		public string chatwork_id;
		public int organization_id;
		public string organization_name;
		public string department;
		public string avatar_image_url;
	}

	[Serializable]
	public class RoomMemberMessage : IRequestParam
	{
		public string body;
		public int self_unread = 0; //0:既読 1:未読
	}

	[Serializable]
	public class RoomMemberMessageReadInfo : IResponseParam
	{
		public int unread_num;
		public int mention_num;
	}

	[Serializable]
	public class Task : IResponseParam
	{
		public int task_id;
		public Room room;
		public AssignedByAccount assigned_by_account;
		public string message_id;
		public string body;
		public int limit_time;
		public string status;
		public string limit_type;
	}

	[Serializable]
	public class FileDetails : IResponseParam
	{
		public int file_id;
		public Account account;
		public string message_id;
		public string filename;
		public int filesize;
		public int upload_time;
	}

	[DataContract]
	public class RoomLink : IRequestParam
	{
		public string code;
		public string description;
		public eNeedAcceptance need_acceptance = eNeedAcceptance.none;
	}

	[DataContract]
	public class RoomLinkDetail : IResponseParam
	{
		[DataMember(Name = "public")]
		public bool is_public;

		[DataMember(Name = "url")]
		public string url;

		[DataMember(Name = "need_acceptance")]
		public bool need_acceptance;

		[DataMember(Name = "description")]
		public string description;
	}
}
