DELIMITER

/* STANDARD STORED PROCEDURE */

              CREATE PROCEDURE [dbo].[spA_BookDetail_i]

                     ?BookId bigint output,

                     ?BookName varchar(128),

                     ?Author varchar(64)=NULL,
                     ?SecAuthor varchar(64)=NULL,
                     ?Press varchar(128),
                     ?Type bit=NULL,
                     ?Status bit=NULL,
                     ?IsActive bit=NULL,D
                     ?icon varchar(256)=NULL,
                     ?Adress varchar(512)=NULL,
                     ?Detail text=NULL,
                     ?CreateData_User varchar(64)=NULL,
					 ?
                     ?DataChange_User varchar(64)=NULL,
					 ?
                     ?DataChange_CreateTime datetime=NULL,
					 ?
                     ?DataChange_LastTime datetime=NULL
           AS
           DECLARE @retcode int, @rowcount int
           SET LOCK_TIMEOUT 1000
           INSERT INTO BookDetail(BookName, Author, SecAuthor, Press, ISNULL(Type,0), ISNULL(Status,0), ISNULL(IsActive,0), icon, Adress,Detail, DataChange_CreateUser,DataChange_CreateTime, DataChange_LastUser, DataChange_LastTime)
           VALUES(@BookName,@Author,SecAuthor,Press,@CreateData_User,@DataChange_User,ISNULL(@DataChange_CreateTime,getdate()),GETDATE(),@PortalImgUrl,ISNULL(@IsManul,(0)),@Weight,ISNULL(@POIID,(0)))
           SELECT @retcode = @@ERROR, @rowcount = @@ROWCOUNT,@BookId=@@IDENTITY
           IF @retcode = 0 AND @rowcount = 0
             RETURN 100
           ELSE
             RETURN @retcode
DELIMITER;


