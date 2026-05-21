ĐẠI HỌC BÁCH KHOA HÀ NỘI
ĐỒ ÁN TỐT NGHIỆP
Game thực tế ảo thể loại bắn súng góc nhìn thứ nhất
sử dụng cử chỉ tay
PHẠM QUỐC ĐẠT
dat.pq215345@sis.hust.edu.vn
```
Chương trình đào tạo: Khoa học máy tính (IT1)
```
Giảng viên hướng dẫn: PGS. TS. Nguyễn Khanh Văn
Chữ kí GVHD
```
Khoa: Khoa học máy tính
```
Trường: Công nghệ Thông tin và Truyền thông
HÀ NỘI, 06/2025
LỜI CẢM ƠN
Trước hết, em xin được gửi lời cảm ơn sâu sắc đến Đại học Bách Khoa Hà Nội nói
chung và Trường Công nghệ Thông tin và Truyền thông nói riêng vì đã cho em
được theo học suốt 4 năm vừa qua, cung cấp cho em một môi trường học thuật đầy
nghiêm túc, chuyên nghiệp, sáng tạo, cùng với cơ sở vật chất hiện đại và đội ngũ
giảng viên đầy tâm huyết.
Tiếp đến, em xin được gửi lời cảm ơn đến thầy Nguyễn Khanh Văn và thầy Trịnh
Thành Trung vì đã hướng dẫn, góp ý và sửa lỗi cho em từng chút trong quá trình
thực hiện đồ án tốt nghiệp này. Sự chỉ bảo tận tâm của hai thầy cùng với những lời
góp ý quý báu đã giúp em vượt qua nhiều khó khăn, vướng mắc để hoàn thành đồ
án tốt nghiệp một cách tốt nhất.
Xin được gửi nhiều lời cảm ơn đến các thành viên trong lớp Khoa học Máy tính
04 - K66 vì đã cùng nhau vượt qua những môn học, những cuộc thi, kỳ thi đầy gian
nan. Đặc biệt là các thành viên trong Lab VR - EdTech do thầy Trịnh Thành Trung
hướng dẫn, cảm ơn vì suốt 3 năm vừa qua đã cùng nhau học tập, nghiên cứu và
thử nghiệm những dự án, những kiến thức mới. Đó sẽ là bàn đạp quan trọng để em
bước tiếp trên con đường học tập và làm việc sau này.
Từ tận đáy lòng, em xin được gửi lời cảm ơn chân thành đến bố mẹ. Người đã
nuôi dưỡng, giáo dục, cung cấp cho em mọi điều em cần, nuôi nấng bảo ban trong
suốt quá trình từ lúc còn bé đến lúc con hoàn thành đồ án tốt nghiệp này. Cảm ơn
vì công ơn dưỡng dục và tỉnh yêu mà bố mẹ đã dành cho con.
Đặc biệt cảm ơn Hà Duy Bách, Lê Tấn Đạt, Lê Tuấn Đạt, Phan Bá Trường. Họ
là những người bạn trân quý nhất. Cảm ơn vì đã giúp đỡ, cảm ơn vì đã động viên,
cảm ơn vì đã cùng vượt qua "Bách Khoa" và làm cho những tháng năm tại đây
thêm rực rỡ.
Cuối cùng, đặc biệt nhất, xin dành lời cảm ơn đến người yêu em, Bùi Thu Huyền
vì đã cùng nhau đi qua những tháng năm cấp 3, những kỳ thi quan trọng nhất cuộc
đời và cả những khó khăn tưởng chừng không thể vượt qua. Cảm ơn vì đã không
rời đi, cảm ơn vì vẫn ở lại.
Cảm ơn, chào tạm biệt và hẹn gặp lại "Bách Khoa"
TÓM TẮT NỘI DUNG ĐỒ ÁN
Sự phát triển vượt bậc của công nghệ thực tế ảo đã mở ra tiềm năng to lớn cho các
tựa game nhập vai, đặc biệt là game bắn súng góc nhìn thứ nhất trên nền tảng thực
tế ảo. Tuy nhiên, phần lớn game thể loại đấy hiện nay vẫn phụ thuộc vào bộ điều
khiển truyền thống, chưa khai thác triệt để khả năng tương tác tự nhiên của cử chỉ
```
tay (gesture), dẫn đến trải nghiệm thiếu chân thực và không tận dụng tối đa sức
```
mạnh của các thiết bị thực tế ảo như Meta Quest 2. Một số giải pháp tích hợp cử
chỉ tay đã được thử nghiệm, nhưng thường gặp khó khăn về độ chính xác, độ trễ
hoặc yêu cầu phần cứng phức tạp, gây cản trở việc tiếp cận người chơi phổ thông.
Vấn đề này đặt ra nhu cầu về một tựa game thực tế ảo tối ưu hóa tương tác gesture,
mang lại trải nghiệm nhập vai mượt mà và dễ tiếp cận.
Đồ án này lựa chọn hướng phát triển một game thực tế ảo bắn súng góc nhìn thứ
nhất sử dụng cử chỉ tay mở ra một lối chơi sang tạo hơn, tránh dập khuôn, tập trung
vào tính trực quan, tương tác giúp người chơi cảm nhận rằng mình có năng lực của
nhân vật trong game. Hướng tiếp cận này mở ra một lối chơi mới nhờ khả năng tận
dụng các thư viện hiện đại như Gesture, OpenXR và Unity Navigation, cho phép
xây dựng hệ thống nhận diện cử chỉ hiệu quả mà không đòi hỏi phần cứng đắt đỏ,
phù hợp với người chơi phổ thông và khai thác tối ưu thiết bị Meta Quest 2.
Giải pháp của đồ án bao gồm xây dựng một thế giới game 3D sống động với các
màn chơi đa dạng, từ chiến đấu với kẻ địch trên mặt đất đến chiến đấu với kẻ địch
ngoài không gian và màn đánh trùm ở cuối cùng. Hệ thống nhận diện cử chỉ cho
phép người chơi thực hiện các thao tác như tấn công, né đòn, lướt, dịch chuyển,
nâng cấp, điều khiển tàu vũ trụ và giải đố cùng với giao diện thân thiện, dễ chơi.
Đóng góp chính của đồ án là một tựa game thực tế ảo bắn súng góc nhìn thứ
nhất tiên phong ứng dụng công nghệ gesture, mang lại trải nghiệm nhập vai chân
thực và dễ tiếp cận, cùng khả năng điều khiển phương tiện bằng gesture mang lại
trải nghiệm điều khiển trực quan và thú vị. Sản phẩm không chỉ có giá trị giải trí
mà còn mở ra hướng phát triển mới cho game thực tế ảo tương tác, góp phần định
hình tương lai của ngành công nghiệp game.
Sinh viên thực hiện
```
(Ký và ghi rõ họ tên)
```
ABSTRACT
```
The remarkable advancement of virtual reality (VR) technology has unlocked tremen-
```
```
dous potential for role-playing games, especially first-person shooter (FPS) games
```
on VR platforms. However, most games of this genre still rely on traditional con-
trollers, failing to fully leverage the natural interactivity of hand gestures. As a
result, the experience often lacks realism and does not take full advantage of the
capabilities offered by modern VR devices such as the Meta Quest 2. While some
gesture-based interaction solutions have been tested, they frequently face chal-
lenges in terms of accuracy, latency, or require complex hardware setups, which
hinders accessibility for casual players.
This issue highlights the need for a VR game that optimizes gesture interaction
to deliver a seamless and approachable immersive experience. This project pro-
poses the development of a VR first-person shooter that utilizes hand gestures to
create a more creative, non-repetitive gameplay experience focused on intuitive-
ness and interactivity—allowing players to truly feel empowered as their in-game
character.
This approach introduces a new style of gameplay by taking advantage of mod-
ern libraries such as Gesture, OpenXR, and Unity Navigation, enabling the imple-
mentation of an effective gesture recognition system without the need for expensive
hardware. This makes the game more accessible to casual players while maximiz-
ing the potential of devices like the Meta Quest 2.
The solution includes the creation of a vibrant 3D game world with diverse lev-
els, ranging from ground-based combat to space battles and a final boss fight. The
gesture recognition system enables players to perform actions such as attacking,
dodging, dashing, teleporting, upgrading, piloting a spaceship, and solving puz-
zles—all through an intuitive and user-friendly interface.
The main contribution of this project is a pioneering VR first-person shooter
that integrates gesture technology to deliver a highly immersive and accessible
gameplay experience. With gesture-based vehicle control, the game offers intuitive
and engaging interactions. This product not only provides entertainment value but
also introduces a new development direction for interactive VR games, helping to
shape the future of the gaming industry.
MỤC LỤC
CHƯƠNG 1. GIỚI THIỆU ĐỀ TÀI......................................................... 1
1.1 Đặt vấn đề............................................................................................ 1
1.2 Mục tiêu đề tài ..................................................................................... 1
1.3 Phạm vi và đối tượng người sử dụng....................................................... 2
1.4 Định hướng giải pháp............................................................................ 3
1.4.1 Định hướng công nghệ................................................................ 3
1.4.2 Mô tả giải pháp.......................................................................... 3
1.4.3 Đóng góp chính và kết quả đạt được............................................. 4
1.5 Bố cục đồ án ........................................................................................ 5
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU............................. 6
2.1 Khảo sát thị trường ............................................................................... 6
2.2 Phân tích các hệ thống hiện có ............................................................... 6
2.2.1 Hệ thống FPS VR sử dụng controller truyền thống ........................ 6
```
2.2.2 Hệ thống FPS VR sử dụng gesture (nhận diện cử chỉ tay)............... 10
```
2.2.3 So sánh tổng quan ...................................................................... 13
2.3 Phân tích yêu cầu.................................................................................. 13
2.4 Mục đích của trò chơi............................................................................ 14
2.5 Định hướng sử dụng.............................................................................. 14
2.6 Cơ sở của định hướng sử dụng ............................................................... 15
CHƯƠNG 3. CÔNG NGHỆ SỬ DỤNG.................................................... 17
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI ...................................................... 20
4.1 Tổng quan trò chơi ................................................................................ 20
4.2 Lối chơi ............................................................................................... 20
4.2.1 Ấn tượng ban đầu....................................................................... 20
4.2.2 Mục tiêu.................................................................................... 21
4.2.3 Tiến trình và luồng trò chơi ......................................................... 21
4.2.4 Nhiệm vụ, thử thách ................................................................... 21
4.3 Cơ chế của trò chơi ............................................................................... 22
4.3.1 Luật .......................................................................................... 22
4.3.2 Mô hình thế giới. ....................................................................... 22
4.3.3 Các hành động của nhân vật........................................................ 24
4.3.4 Luồng màn hình......................................................................... 25
4.4 Điều khiển ........................................................................................... 26
4.5 Cốt truyện ............................................................................................ 29
4.6 Thế giới game ...................................................................................... 30
4.7 Kẻ địch ................................................................................................ 32
4.7.1 Hover Bot.................................................................................. 32
4.7.2 Turret Bot.................................................................................. 33
4.7.3 Large Spaceship......................................................................... 34
4.7.4 Omega Boss .............................................................................. 35
4.8 Màn chơi ............................................................................................. 35
4.8.1 Màn 1 - Hành tinh khởi đầu ........................................................ 35
4.8.2 Màn 2 - Không gian vũ trụ.......................................................... 36
4.8.3 Màn 3 - Hành tinh chết ............................................................... 36
4.9 UI ....................................................................................................... 36
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ ....................................... 38
5.1 Thiết kế kiến trúc.................................................................................. 38
5.1.1 Lựa chọn kiến trúc phần mềm ..................................................... 38
5.1.2 Thiết kế tổng quan...................................................................... 41
5.1.3 Thiết kế chi tiết gói .................................................................... 43
ii
5.2 Thiết kế chi tiết..................................................................................... 48
5.3 Xây dựng ứng dụng............................................................................... 51
5.3.1 Thư viện và công cụ sử dụng....................................................... 51
5.3.2 Kết quả đạt được ........................................................................ 51
5.4 Sản phẩm............................................................................................. 51
5.5 Triển khai ............................................................................................ 57
5.5.1 Môi trường phát triển và triển khai............................................... 57
5.5.2 Quy trình triển khai và cài đặt ..................................................... 58
5.5.3 Tối ưu hóa hiệu suất ................................................................... 58
5.5.4 Kiểm thử và đánh giá thực tế....................................................... 58
5.5.5 Thống kê và phản hồi thử nghiệm ................................................ 59
CHƯƠNG 6. CÁC GIẢI PHÁP VÀ ĐÓNG GÓP NỔI BẬT...................... 60
6.1 Xây dựng hệ thống điều khiển nhân vật bằng cử chỉ ................................. 60
6.1.1 Đặt vấn đề ................................................................................. 60
6.1.2 Giải pháp .................................................................................. 60
6.1.3 Kết quả đạt được ........................................................................ 61
6.2 Xây dựng hệ thống điều khiển tàu vũ trụ bằng cử chỉ ............................... 62
6.2.1 Đặt vấn đề ................................................................................. 62
6.2.2 Giải pháp .................................................................................. 62
6.2.3 Kết quả đạt được ........................................................................ 64
CHƯƠNG 7. KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN ............................. 65
7.1 Kết luận ............................................................................................... 65
7.2 Hướng phát triển................................................................................... 65
7.2.1 Lối chơi .................................................................................... 65
7.2.2 StaticHandGesture ..................................................................... 66
7.2.3 GameManager ........................................................................... 66
iii
7.2.4 EnemyControl ........................................................................... 66
TÀI LIỆU THAM KHẢO......................................................................... 68
DANH MỤC HÌNH VẼ
Hình 2.1 Chuyển động bằng locomotion và shift trong Half-Life: Alyx
[3] . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . 7
Hình 2.2 Hệ thống gravity gloves để cầm nắm đồ trong Half-Life: Alyx
[3] . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . 7
Hình 2.3 Hệ thống gravity gloves để cầm nắm đồ trong Half-Life: Alyx
[3] . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . 8
Hình 2.4 Hệ thống mô phỏng vũ khí thao tác chân thật [4] . . . . . . . . 9
Hình 2.5 Hệ thống giao tiếp trong môi trường nhiều người chơi & tối
ưu hóa chuyển động [4] . . . . . . . . . . . . . . . . . . . . . . . . . 9
Hình 2.6 Hệ thống nhận diện cử chỉ tay để tấn công trong Rogue As-
cent [5] . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . 10
Hình 2.7 Giao diện HUD gắn trên cổ tay trong Rogue Ascent [5] . . . . 11
Hình 2.8 Hệ thống tấn công thực hiện bằng cử chỉ tay như đấm trong
Master of Light [6] . . . . . . . . . . . . . . . . . . . . . . . . . . . 12
Hình 2.9 Hệ thống nâng cấp kỹ năng trong Master of Light [6] . . . . . 12
Hình 3.1 Hệ thống nhận diện cử chỉ tay Gesture . . . . . . . . . . . . . 17
Hình 3.2 Hệ thống Gesture hỗ trợ việc tùy chỉnh cử chỉ . . . . . . . . . 18
Hình 4.1 Gameflow Chart . . . . . . . . . . . . . . . . . . . . . . . . . . 21
Hình 4.2 Screen Chart . . . . . . . . . . . . . . . . . . . . . . . . . . . . 25
Hình 4.3 Cử chỉ tay Point Left Hand . . . . . . . . . . . . . . . . . . . . 26
Hình 4.4 Cử chỉ tay Point Right Hand . . . . . . . . . . . . . . . . . . . 27
Hình 4.5 Cử chỉ tay Open Left Hand . . . . . . . . . . . . . . . . . . . . 27
Hình 4.6 Cử chỉ tay Open Right Hand . . . . . . . . . . . . . . . . . . . 28
Hình 4.7 Cử chỉ tay Left Thumb Up . . . . . . . . . . . . . . . . . . . . 28
Hình 4.8 Cử chỉ tay Left Thumb Down . . . . . . . . . . . . . . . . . . 29
Hình 4.9 Cử chỉ tay Left Shaka . . . . . . . . . . . . . . . . . . . . . . . 29
Hình 4.10 Hành tinh khởi đầu . . . . . . . . . . . . . . . . . . . . . . . . 31
Hình 4.11 Khung cảnh bên ngoài không gian. . . . . . . . . . . . . . . . 31
Hình 4.12 Hành tinh chết. . . . . . . . . . . . . . . . . . . . . . . . . . . 32
Hình 4.13 Hover Bot - kẻ địch thuộc loại robot bay. . . . . . . . . . . . . 33
Hình 4.14 Turret Bot - kẻ địch dạng trụ súng cố định. . . . . . . . . . . . 34
Hình 4.15 Large Spaceship - kẻ địch dạng phi thuyền vũ trụ chuyên chở
các lính của địch. . . . . . . . . . . . . . . . . . . . . . . . . . . . . 34
Hình 4.16 Trùm cuối Omega . . . . . . . . . . . . . . . . . . . . . . . . . 35
v
Hình 4.17 Màn hình dần chuyển đỏ và nhiễu khi mất máu . . . . . . . . . 37
Hình 4.18 Giao diện nâng cấp trực quan . . . . . . . . . . . . . . . . . . 37
Hình 5.1 Biểu đồ phụ thuộc gói của hệ thống . . . . . . . . . . . . . . . 42
Hình 5.2 Thiết kế chi tiết của Player Package . . . . . . . . . . . . . . . 43
Hình 5.3 Thiết kế chi tiết của SpaceShip Package . . . . . . . . . . . . . 44
Hình 5.4 Thiết kế chi tiết của Manager Package . . . . . . . . . . . . . . 45
Hình 5.5 Thiết kế chi tiết của Enemy Package . . . . . . . . . . . . . . . 46
Hình 5.6 Các lớp quan trọng trong việc điều khiển và vận hành trò chơi 48
Hình 5.7 Luồng thực hiện khi người chơi điều khiển nhân vật chính . . 49
Hình 5.8 Luồng thực hiện khi người chơi điều khiển phi thuyền . . . . . 50
Hình 5.9 Khung cảnh nhà chính khi trò chơi bắt đầu. . . . . . . . . . . . 52
Hình 5.10 Hover Bot bị rơi ra từ phi thuyền. . . . . . . . . . . . . . . . . 52
Hình 5.11 Turret Bot cản đường người chơi. . . . . . . . . . . . . . . . . 53
Hình 5.12 Khối cầu năng lượng trung chuyển. . . . . . . . . . . . . . . . 53
Hình 5.13 Cổng không gian để di chuyển giữa hành tinh xanh và bên
ngoài vũ trụ. . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . 54
Hình 5.14 Không gian vũ trụ vô tận. . . . . . . . . . . . . . . . . . . . . . 54
Hình 5.15 Trận chiến trong không gian giữa người chơi và phi thuyền
vũ trụ. . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . 55
Hình 5.16 Cổng không gian bên ngoài hành tinh chết. . . . . . . . . . . . 55
Hình 5.17 Khung cảnh hành tinh chết. . . . . . . . . . . . . . . . . . . . . 56
Hình 5.18 Lối đi vào màn đánh trùm cuối. . . . . . . . . . . . . . . . . . 56
Hình 5.19 Trận chiến giữa người chơi và trùm cuối. . . . . . . . . . . . . 57
vi
DANH MỤC BẢNG BIỂU
Bảng 2.1 So sánh ưu nhược điểm giữa Controller truyền thống và Ges-
```
ture (Hand Tracking) trong game FPS VR . . . . . . . . . . . . . . . 13
```
Bảng 5.1 Danh sách thư viện và công cụ sử dụng . . . . . . . . . . . . . 51
Bảng 5.2 Package details . . . . . . . . . . . . . . . . . . . . . . . . . . 51
Bảng 5.3 Thông số cấu hình thiết bị triển khai trò chơi . . . . . . . . . . 57
vii
DANH MỤC THUẬT NGỮ
Thuật ngữ Ý nghĩa
Component Thành phần chức năng trong Unity, mỗi
component định nghĩa một hành vi
hoặc thuộc tính riêng biệt có thể gắn
vào GameObject
Component-Based Thuật ngữ chỉ phương pháp thiết kế
phần mềm hoặc game dựa trên các
```
thành phần độc lập (Component)
```
Controller Bộ điều khiển vật lý cho thiết bị VR
GameObject Đối tượng cơ bản trong Unity, đóng vai
trò là khối xây dựng cho mọi thành
phần trong màn chơi
Gesture Cử chỉ tay được nhận diện để tương tác
trong game VR
Hand Tracking Công nghệ theo dõi chuyển động bàn
tay và ngón tay
HUD Giao diện hiển thị thông tin trên màn
```
hình (Heads-Up Display)
```
Meta Quest Dòng kính thực tế ảo độc lập của Meta
```
(Oculus Quest cũ)
```
MonoBehaviour Lớp cơ bản cho các script trong Unity
Engine
NavMesh Agent Công nghệ điều hướng trí tuệ nhân tạo
trong môi trường 3D
OpenXR Chuẩn giao diện lập trình ứng dụng mở
cho thực tế ảo và thực tế tăng cường
ĐATN Đồ án tốt nghiệp
viii
DANH MỤC TỪ VIẾT TẮT
Thuật ngữ Ý nghĩa
FPS Bắn súng góc nhìn thứ nhất
IDE Môi trường phát triển tích hợp
SDK Bộ công cụ phát triển phần mềm
UI Giao diện người dùng
UML Ngôn ngữ mô hình hóa thống nhất
UX Trải nghiệm người dùng
VR Thực tế ảo
XR Thực tế mở rộng
XRI XR Interaction Toolkit
ix
CHƯƠNG 1. GIỚI THIỆU ĐỀ TÀI
1.1 Đặt vấn đề
```
Công nghệ thực tế ảo (Virtual Reality - VR) đã thúc đẩy sự phát triển mạnh mẽ
```
của ngành công nghiệp game, đặc biệt với các thể loại yêu cầu tính tương tác cao
```
như game bắn súng góc nhìn thứ nhất (First Person Shooter - FPS). Game FPS VR
```
mang lại trải nghiệm nhập vai chân thực, nhưng các tựa game hiện nay chủ yếu dựa
vào tay cầm điều khiển hoặc nút bấm ảo. Các phương thức này tạo ra khoảng cách
giữa hành động thực tế và tương tác trong môi trường ảo, làm giảm tính nhập vai.
Nghiên cứu từ Đại học W¨urzburg [1] chỉ ra rằng 76% người dùng VR mong muốn
sử dụng cử chỉ tay tự nhiên thay vì các cơ chế điều khiển truyền thống.
Sử dụng cử chỉ tay thay vì tay cầm truyền thông sẽ mở ra một hướng mới sáng
tạo và có những lối chơi độc đáo hơn việc chỉ sử dụng tay cầm thông thường.
Giải quyết bài toán tích hợp cử chỉ tay vào game FPS VR sẽ mang lại nhiều lợi
ích đáng kể. Một hệ thống điều khiển trực quan dựa trên cử chỉ tay có thể tăng mức
độ hứng thú của người chơi, đồng thời giảm thời gian làm quen so với các cơ chế
nút bấm. Người chơi có thể thực hiện các hành động như bắn súng, di chuyển một
cách tự nhiên, nâng cao cảm giác nhập vai và mở rộng đối tượng người dùng, bao
gồm cả những người không quen với tay cầm điều khiển. Các nhà phát triển game
cũng sẽ hưởng lợi từ việc tạo ra trải nghiệm độc đáo, tăng sức cạnh tranh trên thị
trường VR.
Hơn nữa, giải pháp này không chỉ giới hạn trong lĩnh vực trò chơi. Công nghệ
nhận diện cử chỉ tay có tiềm năng ứng dụng trong các lĩnh vực như đào tạo quân
sự, mô phỏng y tế hoặc giao diện điều khiển công nghiệp. Nó còn mở ra khả năng
phát triển các giao diện đa phương thức kết hợp cử chỉ, giọng nói và ánh mắt, cũng
như tạo nền tảng cho việc cá nhân hóa gameplay thông qua thư viện cử chỉ mở. Do
đó, phát triển một tựa game VR FPS sử dụng cử chỉ tay không chỉ đáp ứng nhu cầu
cải thiện trải nghiệm người chơi mà còn đặt nền móng cho việc tiêu chuẩn hóa giao
diện VR, thúc đẩy đổi mới công nghệ trong nhiều ngành.
1.2 Mục tiêu đề tài
Mục tiêu của đề tài là phát triển một tựa game bắn súng góc nhìn thứ nhất tiên
phong trong lĩnh vực thực tế ảo, mang lại trải nghiệm tương tác chân thực và hấp
dẫn. Đề tài tập trung khắc phục hạn chế của các cơ chế điều khiển tay cầm truyền
thống bằng cách tích hợp tương tác cử chỉ tay. Hệ thống cho phép người chơi thực
hiện các hành động như bắn súng, di chuyển, chạy nhanh và né tránh thông qua các
1
CHƯƠNG 1. GIỚI THIỆU ĐỀ TÀI
cử chỉ tự nhiên, bao gồm trỏ tay, tạo hình khẩu súng bằng tay, hoặc mở lòng bàn tay.
Các cử chỉ được thiết kế trực quan, dễ thực hiện, giúp người chơi nhanh chóng làm
quen và tăng hứng thú khi trải nghiệm. Bên cạnh đó, đề tài mở rộng tính ứng dụng
bằng việc tích hợp điều khiển phương tiện, cụ thể là phi thuyền không gian, thông
qua cử chỉ tay. Người chơi có thể nghiêng tàu sang trái hoặc phải, di chuyển hoặc
nâng tàu bằng các thao tác tay riêng biệt. Tính năng này không chỉ tăng cường trải
nghiệm nhập vai mà còn làm phong phú cơ chế gameplay, tận dụng tối đa không
gian ba chiều của VR. Trò chơi được xây dựng trên nền tảng đồ họa 3D, với công
nghệ VR đảm bảo môi trường ảo đạt độ chân thực cao, tạo cảm giác hòa nhập cho
người chơi.
```
Phạm vi đề tài bao gồm các chức năng chính: (i) Tương tác cử chỉ tay: Phát
```
triển thư viện cử chỉ tay để thực hiện các hành động như bắn súng, di chuyển,
```
chạy nhanh và né tránh, đảm bảo độ chính xác và phản hồi nhanh. (ii) Điều khiển
```
phương tiện: Tích hợp cơ chế điều khiển tàu bay bằng cử chỉ tay, bao gồm các thao
```
tác nghiêng, di chuyển và nâng tàu. (iii) Hệ thống AI kẻ địch: Xây dựng hệ thống
```
AI sử dụng NavMesh Agent để kẻ địch tự động tìm kiếm và tấn công người chơi,
```
tăng tính thử thách và tương tác động. (iv) Môi trường 3D nhập vai: Xây dựng
```
thế giới game 3D với công nghệ VR, tối ưu hóa trải nghiệm nhập vai và tương tác
không gian. Các tính năng được lựa chọn vì tính trực quan, dễ áp dụng, giúp người
chơi nhanh chóng nắm bắt cơ chế và duy trì sự hứng thú.
Đề tài không chỉ hướng đến việc nâng cao trải nghiệm chơi game mà còn đặt
nền móng cho các ứng dụng tương tác cử chỉ tay trong các lĩnh vực khác, như mô
phỏng đào tạo hoặc giao diện điều khiển không cần thiết bị vật lý. Hệ thống được
thiết kế để dễ dàng tích hợp vào các nền tảng VR phổ biến, đảm bảo khả năng mở
rộng và ứng dụng thực tế trong tương lai.
1.3 Phạm vi và đối tượng người sử dụng
Tựa game FPS VR được thiết kế để mang lại trải nghiệm hấp dẫn cho người chơi
từ 15 tuổi trở lên, không phân biệt giới tính hay quốc tịch. Bối cảnh trò chơi mang
phong cách hoạt hình, đa dạng và không chứa yếu tố bạo lực, máu me, ánh sáng
nhấp nháy hay tiếng ồn lớn, đảm bảo thân thiện với mọi lứa tuổi và phù hợp cho
người có tình trạng sức khỏe bình thường. Yếu tố này giúp trò chơi thu hút cả trẻ
em, người lớn và những người yêu thích các trải nghiệm nhập vai nhẹ nhàng.
Các thao tác cử chỉ tay, như bắn súng, di chuyển hay điều khiển phương tiện,
yêu cầu phản xạ nhanh, giúp tăng sự hứng thú cho người chơi đã quen với cơ chế
VR. Yếu tố nhập vai được củng cố bởi môi trường 3D chân thực, tạo ấn tượng sâu
sắc với bối cảnh trò chơi và thu hút những người yêu thích khám phá thế giới ảo.
2
CHƯƠNG 1. GIỚI THIỆU ĐỀ TÀI
Tuy nhiên, trò chơi sử dụng nhiều chuyển động trong không gian VR, có thể gây
chóng mặt hoặc say VR, đặc biệt với những người chưa từng trải nghiệm VR trước
đây. Do đó, trò chơi phù hợp hơn với người chơi đã có kinh nghiệm VR hoặc sẵn
sàng làm quen với công nghệ này. Các trung tâm giải trí VR cũng là đối tượng tiềm
năng, vì trò chơi có thể được sử dụng như một sản phẩm giải trí độc đáo, thu hút
khách hàng nhờ tính tương tác cao và không gian nhập vai.
1.4 Định hướng giải pháp
1.4.1 Định hướng công nghệ
Để đạt mục tiêu mang lại trải nghiệm nhập vai chân thực và tương tác cao trong
tựa game bắn súng góc nhìn thứ nhất FPS VR, đồ án triển khai một hệ thống tích
hợp các công nghệ tiên tiến. Thư viện Gesture được sử dụng để trích xuất và nhận
diện các cử chỉ tay, cho phép ghi nhận chính xác các thao tác phức tạp như trỏ
tay, tạo hình khẩu súng, mở lòng bàn tay, hoặc thực hiện các động tác điều khiển
phương tiện. Thư viện này dựa trên các mô hình học máy được huấn luyện trước,
đảm bảo độ nhạy cao và giảm thiểu tỷ lệ nhầm lẫn lệnh, đáp ứng yêu cầu về phản
hồi nhanh trong môi trường game hành động.
Công nghệ Unity 3D được lựa chọn để xây dựng môi trường trò chơi ba chiều
với đồ họa chi tiết, tái hiện không gian ảo sống động, từ các khu vực chiến đấu đến
cảnh quan vũ trụ. Unity 3D hỗ trợ tối ưu hóa hiệu suất trên các nền tảng VR phổ
biến, đảm bảo trải nghiệm mượt mà ngay cả trên các thiết bị cấu hình trung bình.
Hệ thống vật lý của Unity được áp dụng để mô phỏng chuyển động của phi thuyền,
tái hiện chính xác các hành vi như nghiêng, nâng, hoặc di chuyển trong không gian
ba chiều, mang lại cảm giác điều khiển chân thực.
Hệ thống AI kẻ địch sử dụng NavMesh Agent, một công cụ của Unity cho phép
tạo ra các hành vi thông minh. NavMesh Agent hỗ trợ kẻ địch tự động tìm đường,
xác định vị trí người chơi, và thực hiện các chiến thuật tấn công đa dạng, từ bắn
súng trực diện đến di chuyển né tránh. Công nghệ này đảm bảo tính thử thách của
trò chơi, đồng thời tăng cường sự tương tác động giữa người chơi và môi trường ảo.
1.4.2 Mô tả giải pháp
Giải pháp được xây dựng dựa trên các khảo sát về nhu cầu tương tác và trải
nghiệm trong các tựa game FPS VR, đặc biệt là mong muốn sử dụng cử chỉ tay thay
vì tay cầm truyền thống. Hệ thống cử chỉ tay sử dụng thư viện Gesture Recognition
để nhận diện các thao tác tay phức tạp, như trỏ tay để di chuyển, tạo hình khẩu
súng để bắn, hoặc mở lòng bàn tay để né tránh. Các cử chỉ được ánh xạ trực tiếp
với hành động trong game, đảm bảo tính trực quan và giảm thời gian làm quen.
3
CHƯƠNG 1. GIỚI THIỆU ĐỀ TÀI
Cơ chế điều khiển phi thuyền được phát triển dựa trên các hàm vật lý của Unity
giúp điều chỉnh lực đẩy để mô phỏng chuyển động bay, đảm bảo tàu phản ứng
chính xác với các thao tác tay như nghiêng trái/phải hoặc nâng/hạ. Người chơi có
thể thực hiện các nhiệm vụ di chuyển đến địa điểm chỉ định, tăng tính đa dạng cho
gameplay. Hệ thống này được thiết kế để tái hiện cảm giác điều khiển phương tiện
trong không gian, tận dụng tối đa lợi thế của môi trường VR ba chiều.
Hệ thống AI kẻ địch sử dụng NavMesh Agent để tạo ra các hành vi thông minh
và thử thách. Kẻ địch có khả năng tự động tìm đường đến vị trí người chơi, ghi
nhận tọa độ theo thời gian thực, và thực hiện các hành động tấn công như bắn súng
hoặc di chuyển chiến thuật. Hệ thống AI được cấu hình để điều chỉnh độ khó dựa
trên cấp độ người chơi, đảm bảo trải nghiệm cân bằng cho cả người mới và người
chơi có kinh nghiệm. Môi trường trò chơi được xây dựng trên Unity 3D, với các mô
hình 3D chi tiết, hiệu ứng ánh sáng động, và âm thanh không gian, tạo ra không
gian chiến đấu sống động và thân thiện với người dùng.
1.4.3 Đóng góp chính và kết quả đạt được
Tựa game mang lại trải nghiệm nhập vai chân thực thông qua các cơ chế tương
tác đa dạng, bao gồm bắn súng, né tránh, chặn đòn, di chuyển nhanh, và điều khiển
tàu bay trong không gian ba chiều. Lối chơi chính tập trung vào việc đối đầu với
kẻ địch, tránh sát thương, và hoàn thành các nhiệm vụ như di chuyển đến các địa
điểm chỉ định hoặc tiêu diệt mục tiêu. Hệ thống tính điểm đơn giản được tích hợp,
dựa trên các thông số như số lượng kẻ địch tiêu diệt, thời gian hoàn thành nhiệm
vụ, và độ chính xác của các hành động, giúp người chơi đánh giá hiệu suất và duy
trì động lực tham gia.
Hệ thống cử chỉ tay cho phép người chơi thực hiện các hành động một cách tự
nhiên, tăng mức độ hứng thú so với các cơ chế điều khiển truyền thống, đồng thời
giảm thời gian làm quen. Hệ thống AI kẻ địch thông minh, kết hợp với cơ chế điều
khiển tàu, tạo ra trải nghiệm gameplay phong phú, thử thách khả năng phản xạ và
tư duy chiến thuật của người chơi. Trò chơi không chỉ phục vụ mục đích giải trí
mà còn đóng góp vào việc phát triển công nghệ tương tác VR, với tiềm năng ứng
dụng trong các lĩnh vực như mô phỏng đào tạo quân sự, giao diện điều khiển công
nghiệp, hoặc trải nghiệm giáo dục nhập vai.
Hệ thống được thiết kế để dễ dàng tích hợp vào các nền tảng VR phổ biến như
Oculus Quest 2, Oculus Quest 3, Pico, đảm bảo khả năng mở rộng và triển khai
thực tế. Kết quả đạt được không chỉ nâng cao chất lượng trải nghiệm người chơi
mà còn đặt nền móng cho các nghiên cứu tiếp theo về tương tác cử chỉ tay và AI
trong môi trường thực tế ảo, góp phần thúc đẩy đổi mới công nghệ trong ngành
4
CHƯƠNG 1. GIỚI THIỆU ĐỀ TÀI
công nghiệp game và các lĩnh vực liên quan.
1.5 Bố cục đồ án
Phần còn lại của báo cáo đồ án tốt nghiệp này được tổ chức như sau.
Chương 2 trình bày về khảo sát yêu cầu và phân tích chức năng của hệ thống.
Chương này tập trung vào việc thu thập thông tin từ người chơi tiềm năng thông
qua các phương pháp như nghiên cứu các tựa game FPS VR hiện có, nghiên cứu
đánh giá của những người dùng tựa game đó.
Chương 3 giới thiệu các công nghệ sử dụng trong đồ án. Chương này mô tả các
công cụ, thư viện, và nền tảng được áp dụng, bao gồm Unity 3D cho phát triển môi
trường 3D, thư viện Gesture Recognition cho nhận diện cử chỉ tay, NavMesh Agent
cho hệ thống AI kẻ địch, và các hàm vật lý của Unity cho mô phỏng chuyển động
tàu bay. Lý do lựa chọn các công nghệ này sẽ được giải thích, nhấn mạnh tính hiệu
quả, khả năng tương thích với VR, và sự phù hợp với mục tiêu đề tài.
Chương 4 trình bày về thiết kế, triển khai, và đánh giá hệ thống. Phần này bao
gồm kiến trúc tổng thể của trò chơi, thiết kế chi tiết các thành phần như hệ thống
cử chỉ tay, điều khiển tàu bay, AI kẻ địch, và môi trường 3D. Quá trình lập trình và
tích hợp các thành phần sẽ được mô tả, cùng với các phương pháp tối ưu hóa hiệu
suất trên nền tảng VR. Cuối cùng, chương này trình bày quá trình kiểm thử, bao
gồm các kịch bản kiểm thử độ chính xác của cử chỉ, hiệu năng AI, và trải nghiệm
người chơi, kèm theo kết quả đánh giá để đảm bảo hệ thống đáp ứng các yêu cầu
đã đề ra.
Chương 5 mô tả các giải pháp và đóng góp nổi bật. Chương này tập trung vào
các cải tiến kỹ thuật, như tích hợp cử chỉ tay để thay thế tay cầm truyền thống, hệ
thống AI thông minh sử dụng NavMesh Agent, và cơ chế điều khiển tàu bay trong
không gian 3D. Những đóng góp này sẽ được phân tích để làm rõ giá trị của đồ án
đối với lĩnh vực game VR và tiềm năng ứng dụng trong các ngành khác, như mô
phỏng đào tạo hoặc giao diện tương tác.
Chương 6 là kết luận và hướng phát triển. Phần này tổng kết các nội dung chính
của đồ án, đánh giá mức độ hoàn thành mục tiêu ban đầu, và nêu rõ các kết quả
đạt được. Đồng thời, chương sẽ thảo luận về những hạn chế của hệ thống, như khả
năng say VR hoặc yêu cầu phần cứng. Cuối cùng, các hướng phát triển tiếp theo
sẽ được đề xuất, bao gồm cải tiến độ chính xác của cử chỉ tay, mở rộng tính năng
multiplayer, và ứng dụng công nghệ vào các lĩnh vực ngoài giải trí.
5
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
Về hiện trạng về game FPS trong môi trường VR được thực hiện dựa trên ba
nguồn chính: ý kiến người dùng, các hệ thống đã có và các sản phẩm tương tự trên
thị trường. Để đánh giá toàn diện, báo cáo tập trung vào hai hướng phát triển chính:
game sử dụng controller truyền thống và game tích hợp nhận diện cử chỉ tay. Dữ
liệu khảo sát được tổng hợp từ các nghiên cứu học thuật, báo cáo thị trường, trải
nghiệm người dùng cũng như phân tích thực nghiệm trên các tựa game tiêu biểu.
2.1 Khảo sát thị trường
Thị trường game FPS toàn cầu năm 2024 được định giá khoảng 12,25 tỷ USD
và dự báo sẽ đạt 20,45 tỷ USD vào năm 2033 với tốc độ tăng trưởng trung bình
6,5%/năm[2]. Sự phát triển của công nghệ VR đã tạo ra bước chuyển lớn về trải
nghiệm nhập vai, trong đó các game FPS VR đóng vai trò tiên phong nhờ khả năng
tương tác vật lý, cảm giác hiện diện và phản hồi xúc giác vượt trội so với game
truyền thống. Tuy nhiên, mỗi phương thức điều khiển lại có ưu nhược điểm riêng,
ảnh hưởng trực tiếp đến trải nghiệm người chơi.
2.2 Phân tích các hệ thống hiện có
Các hệ thống game FPS VR hiện nay có thể chia thành hai nhóm chính: sử dụng
```
controller truyền thống và sử dụng gesture (nhận diện cử chỉ tay). Mỗi nhóm đều
```
có những tính năng nổi bật và điểm khác biệt rõ rệt.*
2.2.1 Hệ thống FPS VR sử dụng controller truyền thống
Các game FPS VR sử dụng controller như Half-Life: Alyx và Pavlov VR hiện là
chuẩn mực của thể loại này nhờ khai thác tối đa tiềm năng của thiết bị điều khiển
vật lý.
a, Half-Life: Alyx
Tựa game nổi bật với hệ thống di chuyển đa dạng, hỗ trợ nhiều kiểu locomotion
như teleport, shift, continuous và room-scale. Điều này cho phép người chơi tùy
chọn phong cách di chuyển phù hợp với không gian thực tế của mình cũng như khả
năng chịu đựng chuyển động trong môi trường VR, từ đó giảm thiểu cảm giác say
VR và tăng sự thoải mái trong quá trình trải nghiệm. Việc tích hợp nhiều phương
thức di chuyển còn giúp trò chơi tiếp cận được nhiều đối tượng người chơi hơn,
từ những người mới làm quen đến các game thủ kỳ cựu, đồng thời tối ưu hóa trải
nghiệm nhập vai trong từng tình huống cụ thể.
6
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
Hình 2.1: Chuyển động bằng locomotion và shift trong Half-Life: Alyx [3]
Một trong những điểm sáng của Half-Life: Alyx là hệ thống tương tác vật lý cực
kỳ chân thực với môi trường. Người chơi sử dụng “gravity gloves” để kéo vật thể
từ xa, nhặt đồ, thao tác cầm nắm, nạp đạn, mở cửa, giải đố và hack thiết bị điện tử.
Găng tay này không chỉ giúp việc tương tác với các vật thể trở nên trực quan, thú vị
mà còn mở ra nhiều cách giải quyết tình huống sáng tạo, tăng chiều sâu gameplay.
Việc phải thực hiện các thao tác vật lý bằng tay thật như lật bàn, di chuyển vật cản,
hay ném vật thể cũng làm tăng tính nhập vai và cảm giác hiện diện trong thế giới
ảo.
Hình 2.2: Hệ thống gravity gloves để cầm nắm đồ trong Half-Life: Alyx [3]
Hệ thống inventory được thiết kế trực quan, cho phép người chơi lấy và cất vật
phẩm thông qua các chuyển động tự nhiên như đưa tay qua vai hoặc sử dụng cổ tay
để lấy đồ. Điều này giúp thao tác trong game trở nên mượt mà, không bị gián đoạn
7
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
bởi các menu phức tạp. Vũ khí trong game rất đa dạng, mỗi loại đều có thao tác sử
dụng và nạp đạn riêng biệt, đồng thời có thể nâng cấp để phù hợp với phong cách
chiến đấu của từng người chơi. Việc phải thao tác thủ công từng bước khi thay đạn,
lắp phụ kiện hay kiểm tra số lượng đạn còn lại tạo ra thử thách kỹ năng thực sự,
đồng thời tăng tính chân thực và nhập vai.
Hình 2.3: Hệ thống gravity gloves để cầm nắm đồ trong Half-Life: Alyx [3]
Điểm nổi bật khi sử dụng controller với trò chơi này là độ chính xác cao trong
thao tác bắn, nạp đạn, đổi vũ khí nhờ controller có nhiều nút và cảm biến vị trí.
```
Phản hồi xúc giác (haptic feedback) giúp người chơi cảm nhận lực bắn, rung khi
```
bắn súng hoặc nhận sát thương.Đồ họa và âm thanh xuất sắc, hệ thống cốt truyện
sâu, giúp tăng cảm giác nhập vai và kết nối cảm xúc với nhân vật.
b, Pavlov VR
Tính năng chính trong trò chơi bao gồm mô phỏng vũ khí chân thực: người chơi
phải thao tác từng bước như ngoài đời thực, từ việc lắp đạn, kéo khóa nòng, thay
băng đạn cho đến kiểm tra tình trạng vũ khí. Mỗi loại vũ khí đều có những đặc
điểm riêng biệt về độ giật, độ chính xác, tốc độ nạp đạn cũng như cảm giác cầm
nắm, mang lại trải nghiệm sát với thực tế. Điều này đòi hỏi người chơi không chỉ
có kỹ năng bắn súng mà còn phải thành thạo các thao tác vật lý, giúp tăng tính nhập
vai và thử thách trong từng trận đấu.
Trò chơi cung cấp đa dạng chế độ chơi, đáp ứng nhiều phong cách và sở thích
khác nhau: từ các chế độ truyền thống như Deathmatch, Team Deathmatch, Search
and Destroy cho đến những chế độ sáng tạo, giải trí như Gun Game, Trouble in
Terrorist Town, Zombies. Mỗi chế độ đều có luật chơi và mục tiêu riêng, giúp
người chơi luôn cảm thấy mới mẻ, không bị nhàm chán. Ngoài ra, hệ thống bản đồ
8
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
phong phú, được thiết kế tỉ mỉ với nhiều địa hình, vật cản khác nhau, tạo điều kiện
cho các chiến thuật đa dạng và bất ngờ trong từng trận đấu.
Hình 2.4: Hệ thống mô phỏng vũ khí thao tác chân thật [4]
```
Hệ thống huấn luyện (training course) và bắn tập, giúp người mới làm quen với
```
thao tác vũ khí và di chuyển trong môi trường ảo.
Điểm nổi bật của trò chơi là đề cao yếu tố chiến thuật, phối hợp đồng đội và giao
tiếp trong môi trường nhiều người chơi. Mô phỏng âm thanh, không gian và bản đồ
đa dạng, tăng tính thực tế và thử thách. Tối ưu hóa chuyển động để giảm say VR,
hỗ trợ nhiều thiết lập cho người chơi có thể lực và kinh nghiệm khác nhau.
Hình 2.5: Hệ thống giao tiếp trong môi trường nhiều người chơi & tối ưu hóa chuyển động
[4]
9
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
Hệ thống controller truyền thống mang lại trải nghiệm FPS VR ổn định, chính
xác, phù hợp với những người chơi ưu tiên tốc độ, chiến thuật và cảm giác điều
khiển vật lý rõ ràng. Tuy nhiên, thao tác vẫn mang tính “gián tiếp” qua thiết bị,
chưa hoàn toàn tự nhiên như chuyển động tay thật.
```
2.2.2 Hệ thống FPS VR sử dụng gesture (nhận diện cử chỉ tay)
```
Các game FPS VR sử dụng gesture như Hand Physics Lab, Rogue Ascent VR,
Masters of Light đang mở ra hướng tiếp cận mới, tập trung vào sự tự nhiên, trực
tiếp và sáng tạo trong tương tác.
a, Rogue Ascent VR
Rogue Ascent VR là tựa game bắn súng thực tế ảo nổi bật với hệ thống điều
khiển hoàn toàn bằng cử chỉ tay, không cần sử dụng controller truyền thống. Người
chơi có thể thực hiện các thao tác bắn súng thông qua động tác “finger gun” – tạo
hình khẩu súng bằng ngón tay và mô phỏng hành động bóp cò, đồng thời di chuyển
bằng cách chỉ tay tới vị trí mong muốn trên bản đồ. Hệ thống nhận diện cử chỉ tay
này giúp tăng cảm giác tự do, nhập vai và mang lại trải nghiệm tương tác trực quan
hơn so với các phương pháp điều khiển thông thường.
Hình 2.6: Hệ thống nhận diện cử chỉ tay để tấn công trong Rogue Ascent [5]
Một điểm đáng chú ý khác của Rogue Ascent VR là giao diện HUD được gắn
trực tiếp trên cổ tay người chơi, giúp tối ưu hóa khả năng quan sát và thao tác trong
môi trường thực tế ảo. Nhờ thiết kế này, người chơi có thể dễ dàng thực hiện các
thao tác như quét bản đồ, kích hoạt bẫy, nhận các thông báo quan trọng hoặc kiểm
tra tình trạng nhân vật chỉ bằng những cử động tay tự nhiên, không cần rời mắt
khỏi không gian chiến đấu. Hệ thống HUD này còn hỗ trợ các thao tác đặc biệt như
10
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
kích hoạt kỹ năng, đổi vũ khí hoặc sử dụng vật phẩm thông qua các cử chỉ riêng
biệt, góp phần nâng cao sự linh hoạt, tiện lợi và tốc độ xử lý tình huống trong quá
trình chơi. Điều này giúp người chơi luôn chủ động trong mọi tình huống, đồng
thời giảm thiểu sự gián đoạn do phải thao tác với các menu truyền thống.
Hình 2.7: Giao diện HUD gắn trên cổ tay trong Rogue Ascent [5]
Điểm nổi bật nhất của Rogue Ascent VR chính là việc loại bỏ hoàn toàn con-
troller, giải phóng bàn tay và mang lại trải nghiệm tự nhiên, chân thực hơn cho
người chơi. Hệ thống điều khiển bằng cử chỉ tay được tối ưu hóa cho các thao tác
nhanh, đơn giản, giúp cả người mới lẫn người chơi lâu năm đều dễ dàng tiếp cận
và làm quen với trò chơi. Nhờ đó, Rogue Ascent VR phù hợp với nhiều đối tượng,
từ những người mới trải nghiệm thực tế ảo cho đến những game thủ dày dạn kinh
nghiệm. Tuy nhiên, do giới hạn của công nghệ nhận diện bàn tay hiện tại, một số
thao tác phức tạp hoặc đòi hỏi tốc độ cao vẫn có thể gặp khó khăn nhất định, đôi
khi gây ra sự chậm trễ hoặc thiếu chính xác trong thao tác. Dù vậy, Rogue Ascent
VR vẫn được đánh giá rất cao nhờ sự sáng tạo trong thiết kế, khả năng tận dụng tối
đa tiềm năng của công nghệ thực tế ảo và đặc biệt là cảm giác nhập vai sâu sắc, tự
do mà trò chơi mang lại cho người chơi.
b, Masters of Light
Masters of Light là trò chơi thực tế ảo tập trung vào trải nghiệm chiến đấu bằng
cử chỉ tay, mang lại cảm giác nhập vai tự nhiên cho người chơi. Các thao tác tấn
công như bắn năng lượng, phòng thủ hay ra đòn diện rộng đều được thực hiện thông
qua các động tác tay như đấm, vẫy, chém, giúp người chơi cảm nhận rõ ràng hơn
về hành động chiến đấu, giống như đang thực sự tham gia vào trận đấu ngoài đời
thực.
11
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
Hình 2.8: Hệ thống tấn công thực hiện bằng cử chỉ tay như đấm trong Master of Light [6]
Trò chơi còn sở hữu hệ thống nâng cấp kỹ năng đa dạng, cho phép người chơi
mở khóa thêm các cử chỉ mới khi đạt đến cấp độ cao hơn. Điều này không chỉ
tăng tính đa dạng cho gameplay mà còn tạo động lực để người chơi luyện tập và
phát triển kỹ năng cá nhân. Đặc biệt, gameplay của Masters of Light thiên về vận
động toàn thân, đòi hỏi người chơi phải thường xuyên di chuyển, vung tay, phối
hợp nhiều động tác cơ thể, từ đó góp phần rèn luyện sức khỏe và tăng cường thể
lực trong quá trình giải trí.
Hình 2.9: Hệ thống nâng cấp kỹ năng trong Master of Light [6]
Một điểm nổi bật của các trò chơi sử dụng cử chỉ tay như Masters of Light là
hệ thống thao tác trực quan, dễ nhớ, phù hợp với nhiều lứa tuổi và đối tượng người
chơi. Trò chơi không chỉ mang tính giải trí mà còn khuyến khích vận động, giúp
12
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
người chơi vừa thư giãn vừa rèn luyện thể lực. Tuy nhiên, khi số lượng kẻ địch tăng
lên hoặc các thao tác trở nên phức tạp, độ chính xác của hệ thống nhận diện cử chỉ
có thể bị giảm, dẫn đến những gián đoạn nhất định trong trải nghiệm.
Nhìn chung, hệ thống gesture FPS VR như trong Masters of Light đã tận dụng
tốt tiềm năng của công nghệ thực tế ảo, mang lại trải nghiệm tự nhiên, sáng tạo và
nhập vai cho người chơi. Tuy vậy, công nghệ nhận diện cử chỉ hiện tại vẫn còn một
số hạn chế về độ ổn định, tốc độ phản hồi và khả năng nhận biết các thao tác phức
tạp so với controller truyền thống, điều này là thách thức chung của các tựa game
VR hiện nay.
2.2.3 So sánh tổng quan
Tiêu chí Controller truyền thống Gesture Recognition
Độ chính xác Cao, phản hồi nhanh Phụ thuộc thuật toán, dễ
sai lệch nếu thao tác nhanh
hoặc lệch hướng
Tính tự nhiên Hạn chế, thao tác qua nút
bấm
Cao, trực tiếp bằng chuyển
động tay
Độ phức tạp thao
tác
Dễ làm quen, nhiều nút, có
thể gây nhầm
Ghi nhớ nhiều cử chỉ phức
tạp, cần luyện tập
Nhập vai Tốt, nhưng chưa khai thác
hết VR
Rất tốt, tăng cảm giác hiện
diện và chủ động
Hiệu năng Ổn định, yêu cầu phần cứng
vừa phải
Yêu cầu phần cứng cao, dễ
lag nếu tối ưu kém
Đối tượng phù hợp Người chơi FPS truyền
thống
Người thích trải nghiệm
mới, nhập vai sâu
```
Bảng 2.1: So sánh ưu nhược điểm giữa Controller truyền thống và Gesture (Hand Tracking)
```
trong game FPS VR
2.3 Phân tích yêu cầu
Sau quá trình khảo sát kỹ lưỡng, em đã chọn lọc một tập hợp các tính năng cốt
lõi để triển khai cho tựa game bắn súng góc nhìn thứ nhất trong môi trường thực tế
ảo, nhằm đảm bảo hiệu suất ổn định và mang lại trải nghiệm mượt mà. Những tính
năng được giữ lại gồm: cơ chế bắn súng cơ bản tích hợp công nghệ nhận diện cử
```
chỉ tay, hệ thống di chuyển nâng cao (gồm lướt và dịch chuyển), điều khiển phương
```
tiện bằng cử chỉ tay, cùng các yếu tố chiến đấu đặc trưng của thể loại FPS. Cơ chế
bắn súng cho phép người chơi sử dụng các động tác tự nhiên như trỏ tay để ngắm
bắn hoặc tạo hình khẩu súng bằng hai tay để khai hỏa, giúp tăng tính nhập vai và
giảm sự phụ thuộc vào các thiết bị điều khiển truyền thống. Một số tính năng đòi
13
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
hỏi tài nguyên cao như nâng cấp vũ khí hoặc mô phỏng bắn súng chi tiết đã bị loại
bỏ để tránh ảnh hưởng đến hiệu suất và độ trễ trong môi trường VR.
Hệ thống di chuyển được thiết kế để khai thác tối đa không gian ba chiều của
VR, với hai cơ chế chính là lướt và dịch chuyển. Người chơi có thể mở lòng bàn
tay về phía trước để thực hiện chuyển động lướt nhanh để tạo ra yếu tố chiến thuật
trong lối chơi. Trong khi đó, dịch chuyển cho phép người chơi chỉ tay đến vị trí
mong muốn. Việc kết hợp cả hai cơ chế này nhằm đáp ứng đa dạng nhu cầu từ
người chơi yêu thích tốc độ đến người muốn trải nghiệm thoải mái. Bên cạnh đó,
tính năng điều khiển phương tiện bằng cử chỉ tay mang đến trải nghiệm mới mẻ,
cho phép người chơi vận hành tàu bay trong môi trường ảo thông qua các động tác
như nghiêng tay để chuyển hướng, nâng tay để tăng độ cao, hay nắm tay để tăng
tốc. Để đảm bảo hiệu suất, các mô phỏng vật lý trong tính năng này được đơn giản
hóa, chỉ giữ lại các chuyển động cơ bản và loại bỏ các yếu tố phức tạp như lực cản
không khí.
Phần chiến đấu, một yếu tố không thể thiếu trong game FPS, được xây dựng
dựa trên hệ thống trí tuệ nhân tạo sử dụng NavMesh Agent, giúp kẻ địch có thể di
chuyển thông minh, phát hiện người chơi và sử dụng chiến thuật tấn công phù hợp.
Điều này tạo động lực để người chơi cải thiện kỹ năng và phản xạ, đồng thời giữ
chân họ lâu dài. Các tính năng nâng cao như AI đồng đội hay chiến đấu quy mô lớn
bị loại bỏ do vượt quá phạm vi kỹ thuật của dự án. Trong bối cảnh phần lớn game
VR hiện tại vẫn dựa vào tay cầm điều khiển, dự án này tận dụng công nghệ nhận
diện cử chỉ tay để mang đến trải nghiệm hành động nhập vai độc đáo. Với hướng
tiếp cận tập trung vào các tính năng cốt lõi và tối ưu cho thiết bị phổ thông, trò
chơi không chỉ mở ra một hướng đi mới trong thị trường game VR mà còn đặt nền
móng cho việc ứng dụng điều khiển bằng cử chỉ trong các lĩnh vực như đào tạo mô
phỏng hay điều khiển công nghiệp.
2.4 Mục đích của trò chơi
Trò chơi cũng được thiết kế để giảm thiểu các yếu tố gây căng thẳng như bạo
lực đồ họa hoặc ánh sáng nhấp nháy, đảm bảo phù hợp với nhiều đối tượng, từ trẻ
em đến người lớn có nhu cầu giải trí nhẹ nhàng hoặc người dùng VR lần đầu. Cuối
cùng, trò chơi đặt nền móng cho các ứng dụng ngoài giải trí, chẳng hạn như đào tạo
mô phỏng trong quân sự, y tế, hoặc giao diện điều khiển công nghiệp, bằng cách
tiêu chuẩn hóa tương tác cử chỉ tay trong VR.
2.5 Định hướng sử dụng
Tựa game FPS VR được thiết kế để hoạt động độc lập như một sản phẩm giải
trí, triển khai trên các nền tảng VR phổ biến như Oculus Quest 3, Pico 4, hoặc các
14
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
thiết bị tương thích với SteamVR. Với giao diện cử chỉ tay trực quan, trò chơi cho
phép người chơi dễ dàng tham gia mà không cần phụ thuộc vào tay cầm điều khiển,
phù hợp cho các trung tâm giải trí VR, phòng game, hoặc sử dụng cá nhân tại nhà.
Bối cảnh trò chơi mang phong cách hoạt hình sinh động, với các yếu tố hình ảnh
và âm thanh được tối ưu hóa để giảm thiểu nguy cơ say VR, đặc biệt cho những
người mới tiếp cận công nghệ này. Các thao tác như bắn súng, điều khiển tàu bay,
hoặc né tránh được ánh xạ trực tiếp với cử chỉ tay tự nhiên, giúp người chơi nhanh
chóng nắm bắt cơ chế và tập trung vào trải nghiệm nhập vai.
2.6 Cơ sở của định hướng sử dụng
Định hướng sử dụng của trò chơi được xây dựng dựa trên các nghiên cứu gần
đây về tương tác VR và nhu cầu người dùng. Một nghiên cứu của Đại học Stanford
```
(2023) [7] chỉ ra rằng các giao diện dựa trên cử chỉ tay có thể cải thiện hiệu suất
```
thực hiện nhiệm vụ lên đến 30% so với tay cầm truyền thống trong các ứng dụng
VR, nhờ vào tính trực quan và khả năng tái hiện hành động thực tế. Nghiên cứu
này cũng nhấn mạnh rằng các hệ thống nhận diện cử chỉ tiên tiến, sử dụng học máy
và cảm biến độ sâu, có thể giảm độ trễ xuống dưới 0.3 giây, đáp ứng yêu cầu khắt
khe của các trò chơi hành động như FPS. Điều này củng cố tính khả thi của việc
sử dụng thư viện Gesture Recognition trong trò chơi, vốn được huấn luyện để nhận
diện các thao tác phức tạp như tạo hình khẩu súng hoặc điều khiển tàu bay.
```
Các ứng dụng VR tương tự, chẳng hạn như Hand Physics Lab (2021) và Un-
```
```
plugged (2022), đã chứng minh tiềm năng của tương tác cử chỉ tay trong việc tăng
```
cường trải nghiệm người dùng. Hand Physics Lab sử dụng theo dõi tay để mô
phỏng các hành động vật lý như cầm nắm và ném, đạt tỷ lệ hài lòng 92% trong
các đánh giá trên Oculus Store [8]. Tương tự, Unplugged cho phép người chơi mô
phỏng chơi guitar bằng cử chỉ tay, nhận được phản hồi tích cực về tính nhập vai và
dễ sử dụng. Tuy nhiên, cả hai ứng dụng này tập trung vào các nhiệm vụ đơn giản,
trong khi trò chơi FPS VR của đồ án mở rộng phạm vi bằng cách tích hợp các hành
động phức tạp như chiến đấu, điều khiển phương tiện, và tương tác với AI thông
minh, tạo ra một trải nghiệm toàn diện hơn.
Mặc dù trò chơi là một thử nghiệm trong việc tích hợp cử chỉ tay vào FPS VR,
nhà nghiên cứu tin tưởng vào tiềm năng thành công dựa trên nhu cầu ngày càng
```
tăng về giao diện tự nhiên trong VR. Một khảo sát của IEEE VR Conference (2024)
```
[9] cho thấy 68% người chơi VR ưu tiên các trò chơi có cơ chế điều khiển không
cần học trước, đặc biệt trong các thể loại yêu cầu phản xạ nhanh như FPS. Ngoài
ra, khả năng ứng dụng của công nghệ cử chỉ tay trong các lĩnh vực ngoài giải trí,
chẳng hạn như mô phỏng đào tạo phi công hoặc giao diện điều khiển robot, được
15
CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU
```
củng cố bởi các dự án như VR Motion Learning của DARPA (2023), nơi cử chỉ tay
```
được sử dụng để huấn luyện các thao tác phức tạp trong môi trường ảo [10]. Những
yếu tố này cho thấy trò chơi không chỉ đáp ứng nhu cầu giải trí mà còn đóng góp
vào sự phát triển của các giao diện VR đa năng.
Một thách thức tiềm tàng là nguy cơ say VR do chuyển động nhanh trong không
gian ba chiều, đặc biệt với người chơi mới. Để giải quyết, trò chơi tích hợp các tùy
chọn như chế độ teleport và điều chỉnh tốc độ chuyển động, dựa trên các khuyến
```
nghị từ nghiên cứu của University College London (2022) về giảm thiểu say VR
```
[11]. Ngoài ra, việc đảm bảo độ chính xác của nhận diện cử chỉ trong các điều kiện
ánh sáng khác nhau được hỗ trợ bởi các thuật toán học máy tiên tiến, giảm thiểu tỷ
lệ nhầm lẫn xuống dưới 5% trong các thử nghiệm ban đầu. Những biện pháp này
tăng cường khả năng áp dụng thực tế của trò chơi trong các bối cảnh sử dụng đa
dạng.
16
CHƯƠNG 3. CÔNG NGHỆ SỬ DỤNG
Trong quá trình phát triển tựa game bắn súng góc nhìn thứ nhất trong môi trường
thực tế ảo , một yêu cầu quan trọng là xây dựng hệ thống điều khiển tự nhiên, tăng
tính nhập vai và giảm sự phụ thuộc vào tay cầm truyền thống. Để giải quyết vấn
đề này, thư viện Unity XR Hands được sử dụng để triển khai toàn bộ các cơ chế
```
nhận diện cử chỉ tay (hand gesture recognition) trong game, bao gồm bắn súng,
```
```
di chuyển nâng cao (lướt và dịch chuyển), và điều khiển phương tiện. Unity XR
```
Hands, được tài liệu hóa tại Unity Documentation[12], cung cấp khả năng theo dõi
```
vị trí khớp tay (joint tracking) và nhận diện trạng thái tay (hand pose) thông qua dữ
```
liệu từ các cảm biến VR, như camera hồng ngoại trên kính Meta Quest. Cụ thể, thư
viện hỗ trợ phát hiện các cử chỉ như trỏ ngón tay để ngắm bắn, tạo hình khẩu súng
bằng hai tay để khai hỏa, nghiêng lòng bàn tay để kích hoạt cơ chế lướt, trỏ tay để
dịch chuyển tức thời, và nghiêng tay để điều hướng phương tiện.
Hình 3.1: Hệ thống nhận diện cử chỉ tay Gesture
```
Unity XR Hands giải quyết ba vấn đề chính trong đồ án: (1) tăng tính nhập vai
```
bằng cách cho phép người chơi tương tác trực quan qua cử chỉ tay, ví dụ: người
chơi có thể ngắm bắn bằng cách trỏ ngón tay hoặc khai hỏa bằng cách tạo hình
khẩu súng, mang lại cảm giác như đang thực sự sử dụng vũ khí trong không gian
```
ảo; (2) giảm độ phức tạp trong điều khiển, loại bỏ nhu cầu ghi nhớ tổ hợp nút bấm
```
17
CHƯƠNG 3. CÔNG NGHỆ SỬ DỤNG
```
trên tay cầm, vốn có thể gây khó khăn cho người chơi mới; và (3) đảm bảo tính
```
tương thích với các thiết bị VR phổ thông như Meta Quest, vốn đã hỗ trợ hand
tracking sẵn có. Ngoài ra, tính năng Gesture Visualization UI của Unity XR Hands
cho phép hiển thị trực quan các cử chỉ tay trong không gian 3D, giúp lập trình viên
kiểm tra và tinh chỉnh cử chỉ trong quá trình phát triển, đảm bảo độ chính xác và
phản hồi nhanh. Ví dụ, trong cơ chế điều khiển phương tiện, Unity XR Hands nhận
diện cử chỉ nghiêng tay để điều hướng phi thuyền bay, nâng/hạ tay để thay đổi độ
cao, và nắm tay để tăng tốc, tạo ra trải nghiệm điều khiển tự nhiên và trực quan.
Lý do lựa chọn cách tiếp cận hiện tại với Unity XR Hands: Việc tùy chỉnh cử
```
chỉ trong Unity XR Hands (như trỏ ngón tay, nghiêng tay) được chọn vì đáp ứng
```
tốt các yêu cầu cụ thể của game FPS VR, từ bắn súng, di chuyển, đến điều khiển
phương tiện, mang lại trải nghiệm nhập vai và đa dạng. So với việc chỉ dùng cử chỉ
mặc định, cách tiếp cận này linh hoạt hơn và phù hợp với lối chơi hành động nhanh
của FPS. So với tùy chỉnh cử chỉ đơn giản, phương pháp này tăng tính phong phú
cho tương tác, giúp người chơi cảm nhận được sự tự nhiên trong từng hành động.
Cuối cùng, việc không dùng cảm biến bên ngoài đảm bảo tính khả thi trên các thiết
bị VR phổ thông, phù hợp với mục tiêu tối ưu hóa của đồ án.
Hình 3.2: Hệ thống Gesture hỗ trợ việc tùy chỉnh cử chỉ
Sau khi phân tích các tính năng tiềm năng cho tựa game FPS VR, một tập hợp
18
CHƯƠNG 3. CÔNG NGHỆ SỬ DỤNG
con các tính năng được lựa chọn để triển khai, tập trung vào việc sử dụng Unity
XR Hands để đảm bảo trải nghiệm chơi game mượt mà trên các thiết bị VR phổ
```
thông như Meta Quest. Các tính năng bao gồm: (1) cơ chế bắn súng cơ bản, (2) hệ
```
```
thống di chuyển nâng cao với lướt và dịch chuyển, và (3) điều khiển phương tiện,
```
tất cả đều được điều khiển thông qua cử chỉ tay nhờ Unity XR Hands. Những tính
năng này là nền tảng để đảm bảo game hoạt động hiệu quả, vừa nhập vai, vừa ổn
định về mặt kỹ thuật.
Cơ chế bắn súng cơ bản sử dụng Unity XR Hands để nhận diện các cử chỉ như
trỏ ngón tay để ngắm bắn và tạo hình khẩu súng bằng hai tay để khai hỏa, mang
lại cảm giác tự nhiên như đang sử dụng vũ khí thực sự. Hệ thống di chuyển nâng
```
cao tích hợp hai cơ chế: lướt (nghiêng lòng bàn tay để kích hoạt) giúp người chơi
```
```
né đạn hoặc tiếp cận kẻ địch nhanh chóng, và dịch chuyển (trỏ tay để chọn vị trí)
```
nhằm giảm nguy cơ say VR cho người chơi mới. Cả hai đều được triển khai với
Unity XR Hands để đảm bảo tính trực quan và linh hoạt trong không gian ba chiều.
Cơ chế điều khiển phương tiện cho phép người chơi vận hành phi thuyền bay bằng
cách nghiêng tay để điều hướng, nâng/hạ tay để thay đổi độ cao, và nắm tay để tăng
tốc, tận dụng khả năng nhận diện cử chỉ của Unity XR Hands để tạo trải nghiệm
điều khiển nhập vai.
Tựa game FPS VR này tận dụng Unity XR Hands để mang đến một trải nghiệm
hành động độc đáo, kết hợp sự quen thuộc của thể loại FPS với sự đột phá của điều
khiển cử chỉ, tạo nên điểm nhấn trong thị trường game VR. Bằng cách tối ưu hóa
cho thiết bị VR phổ thông, trò chơi không chỉ thu hút người chơi yêu thích hành
động mà còn đặt nền móng cho các ứng dụng tương tác cử chỉ tay trong các lĩnh
vực như đào tạo mô phỏng hoặc giao diện điều khiển công nghiệp, hứa hẹn một
bước tiến mới trong công nghệ VR.
19
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
4.1 Tổng quan trò chơi
• Tên trò chơi: Astral Reclaim
• Bản sắc trò chơi: Trò chơi là một tựa game hành động bắn súng góc nhìn thứ
nhất kế hợp yếu tố phiêu lưu vũ trụ nơi người chơi hóa thân thành một anh
hùng bất đắc dĩ khi quê hương của anh bị tấn công và phải đứng lên để chiến
đấu chống lại kẻ địch, du hành qua vũ trụ tiến đến căn cứ địch để tiêu diệt tận
gốc cái xấu.
• Trụ cột trò chơi
– Nhịp độ nhanh.
– Căng thẳng hồi hộp.
– Vận động.
• Điểm độc đáo:
– Cơ chế di chuyển, hành động, tương tác sử dụng cử chỉ tay một cách tự do
và thú vị.
– Hệ thống phương tiện độc đáo, điều khiển trực quan.
– Phong cảnh trong game hùng vi, đủ sức làm choáng ngợp người chơi.
• Phong cách đồ họa: Trò chơi sử dụng tông màu tươi sáng, phong cách nghệ
thuật stylized, lowpoly.
4.2 Lối chơi
4.2.1 Ấn tượng ban đầu
Khởi đầu người chơi sẽ ở trong tòa trụ sở, nhìn ra ngoài sẽ thấy khung cảnh bình
yên xanh tươi thơ mộng của một nơi tương lai tươi sáng. Thiên nhiên, công trình,
con người hòa hợp với nhau một cách lạ kỳ như thể đây là chốn thiên đường. Tại
đây, người chơi sẽ được tập làm quen với cơ chế di chuyển, chỉ tay để đi xung quanh
ngắm nhìn thế giới.
Sau đó một khoảng thời gian ngắn, một phi thuyền cũ kỹ, kỳ lạ khác biệt hẳn so
với môi trường xung quanh tiến đến, đâm sầm vào tòa trụ sợ chính tăng phần kịch
tính, từ con phi thuyền xuất hiện ra những robot tấn công người chơi, trong đó có
một con robot bị hỏng sau cú va chạm sẽ bắt đầu tấn công người chơi, người chơi
sẽ học cách tấn công vào con robot đó.
20
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
Sau khi hoàn thành tấn công, người chơi sẽ học được kỹ năng né tránh và tiếp
tục tiêu diệt những kẻ địch cản đường với kỹ năng mới.
4.2.2 Mục tiêu
Sự cạnh tranh trong trò chơi bắt nguồn từ việc đối mặt với các nhóm kẻ địch có
cơ chế tấn công đa dạng trên hành trình phiêu lưu liên hành tinh. Chiến binh càng
tiến xa, kỹ năng càng điêu luyện, thì càng phải đối mặt với những thử thách và kẻ
thù nguy hiểm hơn. Do đó, người chơi phải không ngừng rèn luyện kỹ năng bắn
súng, tận dụng tối đa kỹ năng đặc biệt để né tránh và phản công hiệu quả. Họ có
thể thành công bằng cách tiêu diệt toàn bộ kẻ địch cản đường, vượt qua từng thử
thách và hành tinh. Mỗi chiến thắng giúp người chơi mở khóa kỹ năng mới, sở hữu
trang bị mạnh mẽ hơn, từ đó tiến xa hơn trên hành trình tiêu diệt cái ác, trả lại bình
yên cho quê hương.
4.2.3 Tiến trình và luồng trò chơi
Hình 4.1: Gameflow Chart
4.2.4 Nhiệm vụ, thử thách
Trong trò chơi này, nhiệm vụ chính của người chơi của bạn là tiêu diệt trùm cuối
Omega trên Hành Tinh Chết, một hành tinh đầy rẫy nguy hiểm. Để chạm trán với
kẻ thù cuối cùng này, người chơi phải vượt qua hàng loạt thử thách cam go và đối
mặt với các đợt lính lớn do kẻ địch cử đến để cản bước. Người chơi cần trau dồi
21
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
kỹ năng sử dụng các hành động trong game, rèn luyện phản xạ và chiến lược qua
từng trận đấu, dần trở thành một chiến binh lão luyện sẵn sàng cho cuộc chiến định
mệnh. Mỗi thử thách là cơ hội để người chơi hoàn thiện bản thân, chuẩn bị cho trận
chiến cuối cùng nhằm đánh bại cái ác, giành lấy hòa bình cho vũ trụ.
4.3 Cơ chế của trò chơi
4.3.1 Luật
Trong trò chơi người chơi sẽ thực hiện các hành động như di chuyển, bắn súng,
dịch chuyển tức thời qua không gian, và chạy nhanh vượt qua chướng ngại vật.
Người chơi được tự do sáng tạo mọi chiến thuật mà không bị giới hạn, từ lén lút
vượt qua kẻ thù đến lao vào những trận chiến nảy lửa, miễn là chạm được các điểm
chuyển tiếp quan trọng để tiến tới mục tiêu cuối cùng: hạ gục trùm cuối Omega trên
Hành Tinh Chết. Mỗi màn chơi mang đến những thử thách độc đáo với các điểm
chuyển tiếp đặc trưng: ở màn 1, người chơi phải tìm đường đến một phi thuyền của
```
mình đển lên đường tìm đến Hành Tinh Chết; ở màn 2, người chơi cần chinh vượt
```
qua hoạch né tránh các kẻ địch phục kích quanh lối vào hành tinh, một cánh cổng
không gian để xâm nhập vào.
Người chơi sẽ đối mặt với các đợt kẻ địch đa dạng, từ đội quân lính trinh sát
nhanh nhẹn đến cỗ máy chiến đấu khổng lồ, tất cả đều do Omega cử đến để cản
đường. Người chơi không bắt buộc phải tiêu diệt toàn bộ kẻ thù, mà có thể chọn
lọc hạ gục những kẻ cản trở trên lộ trình tự do của mình. Mỗi kẻ địch bị tiêu diệt
sẽ mang lại điểm số, với phần thưởng giá trị hơn khi người chơi triệt hạ các đối thủ
mạnh hoặc hoàn thành các mục tiêu phụ ẩn trong màn chơi. Càng tiêu diệt nhiều
kẻ thù, người chơi càng tích lũy được nhiều điểm tăng thành tích của mình. Tuy
nhiên, người chơi ưa tốc độ có thể chọn chiến thuật speedrun, né tránh giao tranh
để lao thẳng đến các điểm chuyển tiếp và sớm đối mặt với Omega, dù điều này
đồng nghĩa với việc hy sinh điểm số và bỏ lỡ phần thưởng.
Mỗi quyết định trong game đều mang tính chiến lược: người chơi sẽ mạo hiểm
dừng lại để chiến đấu, thu thập điểm và nâng cấp, hoặc liều lĩnh chạy thẳng đến
đích với nguồn lực hạn chế. Các màn chơi được thiết kế để thử thách cả kỹ năng và
sự sáng tạo.
4.3.2 Mô hình thế giới.
a, Cơ chế vật lý của thế giới
Hành tinh khởi đầu.
Hành tinh ban đầu của người chơi sẽ có trọng lực ổn định và các tương tác vật
lý cơ bản như va chạm, ma sát và chuyển động. Người chơi sử dụng các cử chỉ tay
22
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
để di chuyển, bắn súng, dịch chuyển tức thời hoặc chạy nhanh, tương tác với môi
trường như leo đồi, né tránh chướng ngại vật hoặc tận dụng địa hình để tránh kẻ
địch. Điểm chuyển tiếp của màn này là một phi thuyền vũ trụ, nằm ở rìa hành tinh,
sẵn sàng đưa người chơi vào không gian.
Không gian vũ trụ
Màn chơi thứ hai đưa người chơi vào không gian vũ trụ rộng lớn, nơi các thiên
thạch trôi nổi rải rác giữa những đám mây sương mù dày đặc. Môi trường không
trọng lực cho phép người chơi điều khiển phi thuyền vũ trụ, di chuyển tự do và linh
hoạt trong không gian ba chiều. Các phi thuyền của kẻ địch xuất hiện dày đặc, từ
những phi thuyền trinh sát nhỏ gọn đến các chiến hạm lớn, liên tục tấn công để
ngăn cản người chơi. Hành tinh của kẻ địch nằm ngay phía trước, đối diện với hành
tinh xanh tươi mà người chơi vừa rời khỏi ở màn 1, tạo thành một chiến trường
không gian đầy căng thẳng. Vật lý trong màn này phản ánh môi trường không trọng
lực, với các chuyển động trôi nổi, không có ma sát hoặc lực cản đáng kể. Người
chơi cần khéo léo né tránh thiên thạch, sử dụng chúng làm lá chắn hoặc tận dụng
các vụ nổ để đẩy lùi kẻ địch.
Hành tinh chết
Màn này là hành tinh chết, vật lý trong màn này tương tự màn 1, tuân theo các
quy tắc vật lý thông thường với trọng lực, va chạm và ma sát, nhưng địa hình gồ
ghề đòi hỏi người chơi phải sử dụng các cử chỉ chính xác để leo trèo, né tránh hoặc
phá hủy chướng ngại vật. Người chơi cần vận dụng mọi kỹ năng đã rèn luyện để
vượt qua các thử thách địa hình và kẻ địch trước khi đối đầu với Omega trong trận
chiến cuối cùng.
b, Hệ thống kinh tế
Người chơi tích lũy điểm kinh nghiệm bằng cách tiêu diệt kẻ địch trong các màn
chơi. Điểm kinh nghiệm này được sử dụng để nâng cấp các thuộc tính của người
chơi, bao gồm:
• Sức mạnh đạn: Tăng sát thương và hiệu ứng của các phát bắn, giúp hạ gục kẻ
địch nhanh hơn.
• Thời gian hồi chiêu: Giảm thời gian chờ giữa các hành động đặc biệt như
dịch chuyển tức thời hoặc chạy nhanh, cho phép người chơi thực hiện liên tục.
• Tốc độ di chuyển: Cải thiện tốc độ di chuyển và phản xạ, giúp người chơi né
tránh dễ dàng hơn trong chiến đấu hoặc khi vượt qua địa hình phức tạp.
Các nâng cấp này cho phép người chơi tùy chỉnh chiến thuật, từ tập trung vào
23
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
sức mạnh tấn công để tiêu diệt nhiều kẻ địch hơn, đến ưu tiên tốc độ và sự linh hoạt
để tiến nhanh qua các điểm chuyển tiếp. Điểm kinh nghiệm không bị mất khi người
chơi bị tấn công, nhưng việc tiêu diệt ít kẻ địch hơn sẽ hạn chế khả năng nâng cấp,
ảnh hưởng đến hiệu quả trong trận chiến với Omega.
4.3.3 Các hành động của nhân vật
a, Điều khiển nhân vật
Để di chuyển, người chơi thực hiện cử chỉ trỏ tay, hướng ngón tay đến vị trí
```
mong muốn trên mặt phẳng XZ (mặt phẳng ngang). Nhân vật sẽ di chuyển đến vị
```
trí được chỉ định mà không có khả năng nhảy lên theo trục Y, đảm bảo chuyển động
giới hạn trong không gian 2D. Cử chỉ này yêu cầu người chơi giữ tay ổn định để
xác định chính xác điểm đến, phù hợp với các địa hình như đồi cỏ ở màn 1 hoặc bề
mặt gồ ghề ở màn 3.
Người chơi có thể thực hiện các thao tác đặc biệt để tăng tính linh hoạt trong
chiến đấu và di chuyển:
Lao nhanh: Người chơi mở lòng bàn tay trái và hướng về phía mong muốn trên
trục XZ. Nhân vật sẽ lập tức lao nhanh đến vị trí đó với tốc độ cao, hữu ích để né
tránh kẻ địch hoặc vượt qua các khu vực nguy hiểm. Thao tác này yêu cầu người
chơi phối hợp hướng tay chính xác để tránh va chạm với địa hình hoặc kẻ địch.
Dịch chuyển tức thời: Người chơi giơ ngón cái lên và chĩa tay về một vị trí hợp
lệ trên trục XZ. Nếu vị trí được chọn không bị chặn bởi chướng ngại vật hoặc nằm
ngoài phạm vi cho phép, nhân vật sẽ được dịch chuyển ngay lập tức đến đó. Cơ chế
này giúp người chơi nhanh chóng thay đổi vị trí chiến thuật trong các tình huống
căng thẳng. Tính năng này sẽ được mở khóa trong màn 3 của trò chơi.
b, Điều khiển phi thuyền
Điều khiển hướng di chuyển lên xuống của phi thuyền. Người chơi sử dụng
tay trái với các cử chỉ cụ thể. Khi giơ ngón cái tay trái lên, phi thuyền sẽ hướng mũi
lên trên, phù hợp để vượt qua các chướng ngại vật như thiên thạch hoặc định vị lại
trong không gian. Ngược lại, giơ ngón cái tay trái xuống sẽ khiến phi thuyền hướng
xuống dưới, hỗ trợ người chơi khi cần hạ thấp độ cao để né tránh các mối đe dọa từ
phía trên.
Để di chuyển thẳng về phía trước. người chơi trỏ ngón trỏ tay trái thẳng theo
hướng tiến của phi thuyền, đảm bảo phi thuyền duy trì quỹ đạo ổn định. Nếu muốn
điều chỉnh sang trái hoặc phải, người chơi trỏ ngón trỏ tay trái sang hai bên với góc
lệch 15 độ so với trục tiến của phi thuyền, khiến mũi phi thuyền xoay và di chuyển
theo hướng tương ứng, cho phép thực hiện các động tác né tránh hoặc tiếp cận mục
24
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
tiêu.
Để xoay phi thuyền. người chơi úp lòng bàn tay trái xuống và hướng lòng bàn
tay theo hướng mong muốn. Thao tác này cho phép phi thuyền xoay linh hoạt trong
không gian ba chiều, giúp người chơi điều chỉnh góc phi thuyền để né tránh các vụ
nổ, định vị lại hướng tấn công hoặc khám phá các khu vực trong không gian. Cử
chỉ xoay phi thuyền yêu cầu sự phối hợp chính xác để đảm bảo phi thuyền phản
ứng đúng với ý định của người chơi, đặc biệt khi đối mặt với các phi thuyền địch di
chuyển nhanh hoặc các chướng ngại vật bất ngờ.
Để tấn công. người chơi sử dụng tay phải bằng cách trỏ ngón trỏ để kích hoạt
hệ thống bắn đạn của phi thuyền. Thao tác này cho phép phi thuyền bắn liên tục,
phù hợp để đối phó với các nhóm kẻ địch hoặc phá hủy chướng ngại vật nhỏ.
Để khóa tâm kẻ thù. người chơi có thể trỏ ngón trỏ tay phải để ngắm và khóa
tâm một kẻ địch cụ thể, sau đó kích hoạt chế độ bắn tự động. Cơ chế khóa tâm này
tăng độ chính xác, đặc biệt khi đối đầu với các phi thuyền địch di chuyển nhanh
trong không gian vũ trụ, giúp người chơi tập trung vào chiến thuật thay vì phải liên
tục điều chỉnh hướng bắn.
4.3.4 Luồng màn hình
Hình 4.2: Screen Chart
Hình 4.2 thể hiện luồng màn hình của trò chơi. Luồng màn hình này được điều
khiển bởi tay trái khi người chơi thao tác hành động hiện màn hình.
Người chơi sẽ bắt đầu trò chơi tại Welcome Screen. Màn hình này sẽ hiển thị
các lựa chọn gồm: new game, continue, exit game.
Từ Welcome Screen, lựa chọn chức năng Exit Game, trò chơi sẽ hiển thị màn
hình xác nhận để rời khỏi trò chơi.
25
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
Từ Welcome Screen, lựa chọn chức năng New Game hoặc Continue để vào màn
hình BaseGame View. Màn hình BaseGameView sẽ là góc nhìn cơ bản của nhân
vật có thể nhìn thấy môi trường và cảnh vật xung quanh, nhìn thấy kẻ địch và lượng
máu kẻ địch.
Từ BaseGame View, người chơi thực hiện cử chỉ shaka để hiện thị màn hình
Character Option, màn hình này sẽ gồm các nút giúp tăng level cho nhân vật.
Từ màn hình Character Option, bấm vào nút option để vào Option Menu, màn
hình này bao gồm các lựa chọn Save Game và Exit Game, khi bấm vào Save Game
sẽ thực hiện lưu tiến trình trò chơi hiện tại, bao gồm màn chơi, điểm, số quái còn
lại trên map. Khi bấm vào Exit Game sẽ trở về màn hình Welcome Screen.
4.4 Điều khiển
Trò chơi sẽ sử dụng bàn tay của người chơi để điều khiển, hand tracking sẽ ghi
nhận cử chỉ tay và thực hiện hành động của người chơi.
Mỗi cử chỉ tay trong game đều được thiết kế tương ứng với một hành động cụ
thể, giúp người chơi kiểm soát nhân vật hoặc phương tiện một cách trực quan và
hiệu quả. Hệ thống này không chỉ giúp giảm bớt sự phức tạp trong việc ghi nhớ các
nút bấm mà còn mở ra nhiều khả năng sáng tạo trong cách tiếp cận và xử lý tình
huống.
Hình 4.3: Cử chỉ tay Point Left Hand
Hình 4.3 minh họa cử chỉ tay trái trỏ về một hướng xác định. Trong quá trình
chơi, đặc biệt ở màn hình BaseGameView, cử chỉ này được sử dụng để điều khiển
hướng di chuyển của nhân vật hoặc điều chỉnh hướng bay của phi thuyền vũ trụ.
Người chơi chỉ cần đưa tay trái ra và trỏ về phía mong muốn, hệ thống sẽ tự động
nhận diện và thực hiện lệnh di chuyển tương ứng.
26
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
Hình 4.4: Cử chỉ tay Point Right Hand
Hình 4.4 thể hiện cử chỉ tay phải trỏ về một hướng chỉ định. Khi thực hiện cử chỉ
này, bàn tay phải sẽ được chuyển hóa thành hình ảnh một khẩu súng trong game,
cho phép người chơi bắn liên tiếp về phía mục tiêu đã chọn. Đây là thao tác chủ
đạo trong các pha chiến đấu, giúp tăng cảm giác chân thực và chủ động cho người
chơi.
Hình 4.5: Cử chỉ tay Open Left Hand
Hình 4.5 mô tả cử chỉ tay trái mở lòng bàn tay và hướng về phía trước. Khi sử
```
dụng trong các màn điều khiển nhân vật (màn 1 và 3), người chơi có thể lướt nhanh
```
một đoạn ngắn theo hướng đã chọn, giúp né tránh đòn tấn công hoặc di chuyển
nhanh qua các khu vực nguy hiểm. Đây là một kỹ năng quan trọng để tăng tính cơ
động và linh hoạt trong chiến đấu.
27
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
Hình 4.6: Cử chỉ tay Open Right Hand
Hình 4.6 thể hiện cử chỉ tay phải mở lòng bàn tay và trỏ về một hướng. Trong
```
màn điều khiển phi thuyền vũ trụ (màn 2), cử chỉ này cho phép người chơi khóa
```
mục tiêu phi thuyền địch trong phạm vi cho phép và tự động bắn liên tục vào mục
tiêu, giúp kiểm soát các trận chiến không gian hiệu quả hơn.
Hình 4.7: Cử chỉ tay Left Thumb Up
Hình 4.7 minh họa cử chỉ ngón cái tay trái đưa lên, hướng tay chĩa ra phía trước.
```
Trong các màn điều khiển nhân vật (màn 1, 3), cử chỉ này giúp người chơi dịch
```
chuyển tức thời đến vị trí mong muốn, tạo lợi thế trong việc né tránh hoặc tiếp cận
```
mục tiêu. Đối với màn điều khiển phi thuyền (màn 2), động tác này sẽ điều chỉnh
```
hướng mũi phi thuyền lên phía trên, hỗ trợ di chuyển ba chiều trong không gian vũ
trụ.
28
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
Hình 4.8: Cử chỉ tay Left Thumb Down
Hình 4.8 thể hiện cử chỉ ngón cái tay trái đưa xuống và hướng tay chĩa ra. Trong
màn điều khiển phi thuyền, thao tác này sẽ điều chỉnh mũi phi thuyền hướng xuống
dưới, giúp người chơi kiểm soát độ cao của phi thuyền khi di chuyển trong không
gian.
Hình 4.9: Cử chỉ tay Left Shaka
Cuối cùng, hình 4.9 mô tả cử chỉ tay trái tạo hình “shaka” với ngón trỏ và ngón
út đưa ra hai phía. Khi thực hiện, menu chức năng sẽ xuất hiện, cho phép người
chơi truy cập các tùy chọn hoặc thiết lập nhanh mà không cần thoát khỏi dòng trải
nghiệm chính.
4.5 Cốt truyện
Trong tương lai khi nền văn minh của con phát triển, nhu cầu về năng lượng
càng ngày càng trở nên khan hiếm. Con người bắt đầu chế tạo ra những robot có
khả năng hấp thụ năng lượng lõi của hành tinh, hâu quả là các hành tinh dần cạn
kiệt năng lượng và trở nên khô héo. Thấy được hậu quả này, con người chia thành
29
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
hai phe phái, một phe ủng hộ năng lượng xanh sử dụng các nguồn năng lượng sạch
tự nhiên, một phe ủng hộ sử dụng công nghệ hút lõi năng lượng của các hành tinh.
Mâu thuẫn nội bộ giữa loài người đã dẫn đến việc hai phe tách ra ở các hành tiêng
riêng, một bên chọn chung sống hòa bình với thiên nhiên duy trì hành tinh xanh,
một bên liên tục hút cạn tài nguyên của các hành. Trong một thời gian dài yên bình
thì đến một ngày tài nguyên của phe ủng hộ công nghệ hút lõi năng lượng đã cạn
kiệt, con người trên hành tinh này dần đi đến hồi kết, nhưng những robot do họ tạo
ra vẫn còn hoạt động và mục tiêu của chúng vẫn là đi xâm lược các hành tinh khác.
Đến một ngày không tìm thấy hành tinh nào phù hợp nữa, các robot quay sang tấn
công những con người ở hành tinh ủng hộ năng lượng xanh. Từ đây dẫn đến mở
đầu cho câu truyện trong tựa game.
Nhân vật chính là một cư dân tại hành tinh khởi đầu xinh đẹp, nơi mà cây cối
xanh tươi tràn ngập xung quanh, những cối xoay gió và nguồn tài nguyên sạch vô
tận. Một ngày, xuất hiện những tên robot với dáng vẻ cũ kỹ, hung hãn tấn công
nhằm chiếm lấy hành tinh xinh đẹp. Nhân vật chính bất đắc dĩ trở thành một anh
hùng đứng ra giải cứu hành tinh. Sau khi tiêu diệt toàn bộ quân đội robot đổ bộ ở
hành tinh khởi đầu, nhân vật chính nhận thấy sự xâm lược của quân đội robot lan
rộng, từ đó nhân vật chính quyết tâm tiêu diệt tận gốc thế lực robot tàn ác.
4.6 Thế giới game
Hình 4.10 thể hiện thiết kế thế giới game cho màn 1. Khi trò chơi bắt đầu, người
chơi ở trong hành tinh khởi đầu, bên dưới là mặt cỏ xanh tươi, nhìn ra ngoài có thể
thấy được những khối kiến trúc công nghệ cao của nền văn minh phát triển, vị trí
người chơi đứng là căn cứ chỉnh. Giai đoạn tiếp theo thế giới bắt đầu thay đổi khi
căn cứ chính xảy ra sự cố nghiêm trọng: một phi thuyền vũ trụ rơi xuống, gây ra
các đám cháy lớn ở nhiều khu vực khác nhau. Từ xác phi thuyền rơi này, các kẻ
địch bắt đầu xuất hiện và tràn ra tấn công căn cứ, khiến không gian vốn yên bình
trở nên hỗn loạn, nguy hiểm. Người chơi phải nhanh chóng thích nghi, sử dụng kỹ
năng chiến đấu để tiêu diệt kẻ địch, bảo vệ căn cứ và chuẩn bị cho hành trình tiếp
theo là bay vào không gian vũ trụ nhằm truy tìm nguồn gốc thực sự của mối đe
dọa.
30
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
Hình 4.10: Hành tinh khởi đầu
Sau khi rời khỏi hành tinh khởi đầu, người chơi sẽ bước vào không gian vũ trụ
rộng lớn như minh họa ở Hình 4.11. Đây là một môi trường không trọng lực, nơi
người chơi chỉ có thể di chuyển bằng phi thuyền vũ trụ. Không gian vũ trụ được
thiết kế với các vì sao, hành tinh xa xôi và những thiên thể trôi nổi, tạo nên cảm
giác cô lập, thử thách khả năng điều hướng và sinh tồn của người chơi trong môi
trường khắc nghiệt.
Hình 4.11: Khung cảnh bên ngoài không gian.
Cuối cùng, hành trình của người chơi sẽ dẫn đến hành tinh chết, nơi trú ngụ của
boss cuối như thể hiện ở Hình 4.12. Đây là một hành tinh đã bị tàn phá nặng nề,
cạn kiệt tài nguyên, không còn sự sống mà chỉ còn lại những tàn tích đổ nát và các
robot lang thang. Bầu không khí u ám, ô nhiễm cùng cảnh vật hoang tàn tạo nên
cảm giác căng thẳng, báo hiệu trận chiến quyết định với kẻ địch mạnh nhất đang
31
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
chờ đợi phía trước. Việc di chuyển qua các môi trường khác nhau không chỉ làm
phong phú trải nghiệm mà còn tăng dần độ khó, thử thách khả năng thích nghi và
chiến đấu của người chơi trong suốt quá trình khám phá thế giới game.
Hình 4.12: Hành tinh chết.
4.7 Kẻ địch
Trong suốt quá trình trải nghiệm, người chơi sẽ phải đối mặt với nhiều loại kẻ
địch đa dạng, mỗi loại đều sở hữu đặc điểm, hành vi và mức độ nguy hiểm riêng,
góp phần tạo nên sự kịch tính và thử thách cho từng màn chơi. Các kẻ địch không
chỉ khác nhau về ngoại hình mà còn về chiến thuật tấn công, khả năng di chuyển
cũng như cách tương tác với môi trường xung quanh. Một số kẻ địch có thể tấn
công trực diện với hỏa lực mạnh, trong khi những loại khác lại sử dụng chiến thuật
di chuyển linh hoạt hoặc phối hợp theo nhóm để gây áp lực lên người chơi. Sự đa
dạng này buộc người chơi phải liên tục thay đổi chiến thuật, tận dụng tối đa các kỹ
năng cá nhân và khả năng sử dụng vũ khí cũng như môi trường để sinh tồn. Ngoài
ra, mỗi loại kẻ địch còn được thiết kế với điểm yếu và phần thưởng riêng, giúp tăng
động lực khám phá, luyện tập và phát triển kỹ năng chiến đấu. Nhờ vậy, trải nghiệm
game luôn giữ được sự tươi mới, hấp dẫn và lôi cuốn qua từng màn chơi, đồng thời
góp phần tạo nên chiều sâu cho thế giới ảo mà người chơi đang chinh phục.
4.7.1 Hover Bot
Hover Bot là loại kẻ địch xuất hiện ở cả màn 1 và màn 3, đóng vai trò như
những robot bay trinh sát linh hoạt. Với kích thước nhỏ gọn và khả năng di chuyển
trên không, Hover Bot có thể dễ dàng tiếp cận hoặc né tránh các đòn tấn công
của người chơi, khiến việc tiêu diệt chúng trở nên khó khăn hơn so với các kẻ địch
32
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
thông thường. Khi tấn công, Hover Bot gây ra lượng sát thương vừa phải, tuy không
quá nguy hiểm nếu chỉ xuất hiện đơn lẻ, nhưng khi xuất hiện theo nhóm, chúng có
thể phối hợp áp sát, gây áp lực lớn lên người chơi, đặc biệt trong các tình huống
bị bao vây hoặc phải chiến đấu trên nhiều mặt trận cùng lúc. Ngoài khả năng tấn
công, Hover Bot còn đóng vai trò trinh sát rất hiệu quả, có thể phát hiện vị trí người
chơi và báo động cho các kẻ địch khác. Sau khi bị tiêu diệt, Hover Bot sẽ rơi ra ba
điểm nâng cấp kỹ năng, giúp người chơi tăng cường sức mạnh và mở rộng lựa chọn
chiến thuật cho các thử thách tiếp theo.
Hình 4.13: Hover Bot - kẻ địch thuộc loại robot bay.
4.7.2 Turret Bot
Turret Bot là loại kẻ địch cố định, thường xuất hiện ở những vị trí trọng yếu
trong màn 1 và màn 3. Chúng có hình dạng như các trụ súng phòng thủ, được trang
bị cảm biến phát hiện chuyển động từ xa và khả năng tấn công liên tục bằng hỏa
lực tầm xa. Mặc dù sát thương mỗi phát bắn không quá cao, nhưng tốc độ bắn liên
tục khiến chúng trở thành mối đe dọa lớn nếu người chơi không chú ý né tránh hoặc
tìm cách tiêu diệt từ xa. Điểm yếu duy nhất của Turret Bot là không thể di chuyển,
vì vậy nếu phát hiện được vị trí của chúng, người chơi có thể lên kế hoạch tiếp cận
và loại bỏ mà không phải lo lắng về việc bị truy đuổi. Turret Bot sẽ rơi ra năm điểm
nâng cấp kỹ năng, mang lại phần thưởng xứng đáng cho những ai vượt qua được
thử thách này.
33
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
Hình 4.14: Turret Bot - kẻ địch dạng trụ súng cố định.
4.7.3 Large Spaceship
Large Spaceship là loại kẻ địch xuất hiện chủ yếu trong màn 2, đóng vai trò như
những phi thuyền không gian chiến đấu cỡ lớn của phe địch. Những phi thuyền này
sở hữu hỏa lực mạnh mẽ, có thể gây sát thương cực lớn nếu người chơi bị trúng đòn
trực diện. Large Spaceship thường di chuyển tuần tra quanh các khu vực trọng yếu
trong không gian, tạo thành những “bức tường di động” khó vượt qua. Tuy nhiên,
điểm yếu của chúng là tốc độ di chuyển khá chậm so với phi thuyền của người chơi,
cho phép người chơi có cơ hội né tránh hoặc tìm đường trốn thoát khi bị phát hiện
và truy đuổi. Large Spaceship chỉ tấn công khi người chơi tiến lại quá gần, vì vậy
việc lựa chọn lộ trình di chuyển hợp lý sẽ giúp giảm nguy cơ bị tấn công bất ngờ.
Khi bị tiêu diệt, loại kẻ địch này sẽ rơi ra tới mười điểm nâng cấp kỹ năng, là phần
thưởng lớn cho những ai đủ bản lĩnh đối đầu trực tiếp.
Hình 4.15: Large Spaceship - kẻ địch dạng phi thuyền vũ trụ chuyên chở các lính của địch.
34
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
4.7.4 Omega Boss
Omega Boss là kẻ địch cuối cùng, xuất hiện ở màn 3 và đóng vai trò trùm cuối
của toàn bộ trò chơi. Đây là một thực thể cực kỳ mạnh mẽ, sở hữu các đòn tấn công
năng lượng diện rộng với sức công phá lớn, đòi hỏi người chơi phải vận dụng tối đa
kỹ năng di chuyển, né tránh và phản ứng nhanh để sống sót. Các đòn tấn công của
Omega Boss thường có phạm vi rộng, tốc độ cao và có thể thay đổi liên tục, tạo ra
áp lực lớn, buộc người chơi phải luôn cảnh giác và chủ động tìm kiếm các khoảng
trống an toàn. Đánh bại Omega Boss không chỉ là thử thách về kỹ năng cá nhân
mà còn là đỉnh cao của hành trình chinh phục thế giới game, đánh dấu sự kết thúc
của toàn bộ cốt truyện. Khi hạ gục được trùm cuối, người chơi sẽ mở khóa toàn
bộ phần thưởng và hoàn thành trò chơi, để lại dấu ấn về một trận chiến cam go và
xứng đáng.
Hình 4.16: Trùm cuối Omega
4.8 Màn chơi
4.8.1 Màn 1 - Hành tinh khởi đầu
Ở màn chơi đầu tiên, người chơi bắt đầu tại trụ sở chính trên hành tinh khởi đầu,
trong một không gian yên bình trước khi bị tấn công. Ngay từ đầu, người chơi được
trang bị vũ khí cơ bản cùng hai kỹ năng là khiên phòng thủ và lao nhanh. Những
thử thách đầu tiên sẽ giúp người chơi làm quen với thao tác bắn súng và sử dụng
khiên, thông qua việc đối đầu với các kẻ địch xuất hiện trên nóc trụ sở. Sau đó,
người chơi sẽ tiếp tục luyện tập kỹ năng chiến đấu khi phải đối phó với các đợt
tấn công nhỏ lẻ của Hover Bot – loại robot bay linh hoạt, buộc người chơi phải di
chuyển và ngắm bắn chính xác hơn.
Tiếp theo, người chơi sẽ gặp Turret Bot – kẻ địch cố định với hỏa lực mạnh,
thường được bố trí ở những vị trí có nhiều vật cản xung quanh. Lúc này, kỹ năng
lao nhanh sẽ phát huy tác dụng, giúp người chơi ẩn nấp và di chuyển an toàn giữa
35
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
các vật cản để tiếp cận và tiêu diệt Turret Bot. Sau khi vượt qua các thử thách này,
người chơi sẽ tiến vào khu vực tháp trung tâm với hai cột lớn, nơi chứa phi thuyền.
Tại đây, người chơi sẽ được hướng dẫn cách điều khiển phi thuyền và sử dụng cổng
dịch chuyển không gian để sang màn tiếp theo.
4.8.2 Màn 2 - Không gian vũ trụ
Ở màn chơi thứ hai, bối cảnh chuyển sang không gian vũ trụ rộng lớn. Người
chơi xuất hiện bên ngoài hành tinh, phía trước là hành tinh mục tiêu cần tiếp cận.
Trong quá trình di chuyển bằng phi thuyền, người chơi phải khéo léo né tránh
các thiên thạch trôi nổi, đồng thời có thể lựa chọn tấn công các phi thuyền Large
Spaceship để kiếm thêm điểm nâng cấp kỹ năng. Tuy nhiên, việc đối đầu với các
phi thuyền địch này tiềm ẩn nhiều rủi ro do hỏa lực mạnh, đòi hỏi người chơi phải
cân nhắc giữa việc tấn công để nhận phần thưởng và ưu tiên an toàn để hoàn thành
nhiệm vụ. Khi đến gần hành tinh chết, người chơi cần tìm cổng dịch chuyển không
gian để tiến vào màn cuối cùng.
4.8.3 Màn 3 - Hành tinh chết
Màn cuối cùng đưa người chơi đến một hành tinh chết, nơi cảnh vật hoang tàn,
đầy rẫy các tàn tích và robot địch. Tại đây, người chơi được trang bị thêm khả năng
dịch chuyển tức thời, giúp dễ dàng di chuyển giữa các tảng đá nhô lên trên mặt đất
– đây cũng là môi trường lý tưởng để luyện tập kỹ năng mới này. Đỉnh điểm của
màn chơi là trận chiến với boss cuối, diễn ra tại khu vực trung tâm được bao quanh
bởi các tảng đá lớn. Người chơi phải tận dụng tối đa kỹ năng di chuyển, né tránh và
tấn công để đánh bại boss cuối cùng. Khi tiêu diệt được boss, người chơi sẽ hoàn
thành trò chơi, kết thúc hành trình chinh phục các thử thách của thế giới ảo.
4.9 UI
Giao diện người dùng của trò chơi được thiết kế tối giản, hạn chế tối đa các
thành phần HUD không cần thiết để tăng cảm giác nhập vai và giúp người chơi tập
trung hoàn toàn vào thế giới ảo. Thay vì sử dụng các thanh máu, chỉ số hay biểu
tượng truyền thống xuất hiện liên tục trên màn hình, trò chơi ưu tiên các hiệu ứng
trực quan, phản ánh trực tiếp trạng thái của nhân vật.
36
CHƯƠNG 4. THIẾT KẾ TRÒ CHƠI
Hình 4.17: Màn hình dần chuyển đỏ và nhiễu khi mất máu
Ví dụ, như thể hiện ở Hình 4.17, khi nhân vật bị mất máu, các hiệu ứng hình
ảnh như màn hình chuyển sang màu đỏ, xuất hiện các tia máu và hiệu ứng nhiễu
sẽ dần bao phủ tầm nhìn của người chơi. Mức độ của hiệu ứng này tăng dần theo
lượng máu mất, giúp người chơi dễ dàng nhận biết tình trạng nguy hiểm mà không
cần nhìn vào các chỉ số cụ thể, từ đó giữ được sự liền mạch và tự nhiên trong trải
nghiệm.
Hình 4.18: Giao diện nâng cấp trực quan
Bên cạnh đó, các chức năng nâng cấp kỹ năng và tùy chọn hệ thống được bố trí
trong giao diện riêng, chỉ xuất hiện khi người chơi chủ động truy cập, như minh
họa ở Hình 4.18. Giao diện này được thiết kế trực quan, dễ thao tác, giúp người
chơi nhanh chóng lựa chọn nâng cấp hoặc điều chỉnh các tùy chọn mà không làm
gián đoạn dòng chảy của trò chơi. Nhờ vậy, UI vừa đảm bảo cung cấp đầy đủ thông
tin cần thiết, vừa giữ cho trải nghiệm thực tế ảo luôn liền mạch và chân thực.
37
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
5.1 Thiết kế kiến trúc
5.1.1 Lựa chọn kiến trúc phần mềm
Trò chơi được phát triển dựa trên kiến trúc Component-Based, một mô hình
thiết kế phổ biến trong các game engine như Unity, phù hợp với các ứng dụng VR
yêu cầu tính linh hoạt và tương tác thời gian thực. Kiến trúc này được áp dụng
bằng cách tổ chức mã nguồn thành các component độc lập, sử dụng các script
```
MonoBehaviour gắn vào GameObjects để quản lý cả dữ liệu (như trạng thái cử chỉ
```
```
tay, sức khỏe, thông số) và logic xử lý (như điều khiển di chuyển, tấn công, tương
```
```
tác giao diện người dùng). Mỗi component được thiết kế để thực hiện một chức
```
năng cụ thể, ví dụ, xử lý cử chỉ tay để bắn súng, điều khiển phi thuyền vũ trụ, quản
lý hành vi của các loại kẻ địch, hoặc xử lý các nút bấm trong UI. Cách tiếp cận này
cho phép triển khai nhanh các tính năng như dịch chuyển tức thời, tấn công laser,
hoặc tương tác UI, đồng thời duy trì tính mô-đun để dễ dàng mở rộng hoặc điều
chỉnh.
a, Thành phần chính của Kiến trúc
Kiến trúc Component-Based được xây dựng dựa trên hai thành phần chính:
• GameObjects: Các đối tượng trong trò chơi, đóng vai trò như các thực thể
chứa các component, ví dụ như nhân vật người chơi, phi thuyền vũ trụ, bốn
loại kẻ địch, điểm chuyển tiếp, hoặc các vật thể môi trường. Mỗi GameObject
được gắn các component để xác định hành vi và trạng thái của nó.
• Components: Các script MonoBehaviour gắn vào GameObjects, chứa cả dữ
```
liệu (như vị trí, sức khỏe, trạng thái cử chỉ) và logic xử lý (như di chuyển, tấn
```
```
công, hoặc tương tác UI). Các component được thiết kế độc lập, cho phép dễ
```
dàng thêm hoặc sửa đổi tính năng mà không ảnh hưởng đến toàn bộ hệ thống.
b, GameObjects trong Trò chơi
GameObjects được sử dụng để đại diện cho các đối tượng chính trong ba màn
chơi của trò chơi:
• Nhân vật người chơi: Xuất hiện trong màn 1 và màn 3, được điều khiển bằng
cử chỉ tay để thực hiện các hành động như di chuyển, bắn súng, hoặc chắn
đạn. Các component như PlayerAction và PlayerHealthController được gắn để
quản lý hành động và sức khỏe, cho phép người chơi tương tác với kẻ địch
hoặc môi trường.
38
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
• phi thuyền vũ trụ: Có mặt trong màn 2, cho phép người chơi điều khiển để di
chuyển, xoay, và bắn trong không gian. Các component như SpaceShipCon-
troller và PlayerShipAction được gắn để xử lý các hành động này, đảm bảo trải
nghiệm điều khiển mượt mà.
• Kẻ địch: Bao gồm bốn loại, mỗi loại có hành vi riêng biệt:
– HoverBot: Kẻ địch di chuyển lơ lửng, xuất hiện ở màn 1 và màn 3, tấn
công người chơi bằng các đòn bắn cơ bản. Component EnemyControl và
DetectionModule được sử dụng để điều khiển di chuyển và nhắm mục
tiêu.
– Turret: Kẻ địch cố định, bắn đạn tự động khi phát hiện người chơi, xuất
hiện ở màn 1 và màn 3. Component LazerAttackController được gắn để
quản lý tấn công laser.
– SpaceFighterShip: Phi thuyền địch di chuyển nhanh, xuất hiện ở màn 2,
nhắm vào phi thuyền người chơi với các đòn tấn công linh hoạt. Com-
ponent DetectionModule và EnemyControl được sử dụng để xử lý hành
vi.
– Boss cuối: Kẻ địch mạnh nhất ở màn 3, yêu cầu người chơi sử dụng tất cả
kỹ năng để đánh bại. Component DetectionModule và LazerAttackCon-
troller được gắn để thực hiện các đòn tấn công phức tạp.
• Điểm chuyển tiếp: Các đối tượng như phi thuyền vũ trụ ở màn 1 hoặc cánh
cổng ở màn 2, cho phép chuyển giữa các màn. Component GameManager
được sử dụng để kiểm tra tương tác với các điểm này.
• Môi trường: Các vật thể như địa hình, chướng ngại vật, hoặc tàn tích, được
gắn Transform và Collider để hỗ trợ tương tác vật lý với người chơi, phi thuyền,
hoặc kẻ địch.
c, Components
Các component được triển khai dưới dạng script MonoBehaviour, mỗi script
chứa dữ liệu và logic để thực hiện một chức năng cụ thể, đảm bảo tính độc lập và
dễ tái sử dụng. Các component chính bao gồm:
• Components của Unity:
– Transform: Lưu trữ và cập nhật vị trí, xoay, và tỷ lệ của GameObjects, ví
dụ, di chuyển nhân vật người chơi theo cử chỉ trỏ tay hoặc xoay phi thuyền
vũ trụ theo cử chỉ úp lòng bàn tay.
– Rigidbody: Quản lý vật lý, như áp dụng trọng lực cho nhân vật ở màn 1
39
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
và màn 3, hoặc cho phép phi thuyền vũ trụ di chuyển tự do trong không
gian ở màn 2. Component này được cấu hình để xử lý va chạm và vận tốc,
ví dụ, khi phi thuyền va chạm với thiên thạch hoặc SpaceFighterShip.
– Collider: Xử lý va chạm giữa nhân vật, phi thuyền, kẻ địch, và môi trường.
BoxCollider được sử dụng cho nhân vật và MeshCollider cho các vật thể
phức tạp như SpaceFighterShip hoặc địa hình, đảm bảo phát hiện va chạm
chính xác.
• Components được thêm vào:
– StaticHandGesture: Thu nhận dữ liệu cử chỉ tay từ XRHandTrackingEvent,
lưu trữ trạng thái như vị trí ngón tay hoặc góc bàn tay, và xử lý các cử chỉ
như trỏ tay để di chuyển, mở lòng bàn tay trái để lao nhanh, hoặc giơ ngón
cái để dịch chuyển tức thời. Component này được sử dụng ở màn 1 và màn
3 để điều khiển nhân vật, và ở màn 2 để điều khiển phi thuyền.
– PlayerAction: Quản lý các hành động của nhân vật người chơi, lưu trữ dữ
liệu như vị trí đích hoặc trạng thái bắn, và thực hiện logic để di chuyển
```
(theo trục XZ), lao nhanh, dịch chuyển tức thời, bắn (giơ ngón trỏ tay
```
```
phải), hoặc chắn đạn (mở lòng bàn tay phải). Component này tích hợp với
```
StaticHandGesture để phản ứng theo cử chỉ, được áp dụng ở màn 1 và
màn 3.
– PlayerHealthController: Lưu trữ giá trị sức khỏe của người chơi và xử
lý logic hồi máu khi nhặt vật phẩm từ HoverBot hoặc Turret, hoặc trừ máu
khi bị tấn công bởi kẻ địch hoặc boss cuối. Component này được cấu hình
để hồi đầy máu khi nhặt vật phẩm, đảm bảo người chơi tiếp tục chiến đấu
ở màn 1 và màn 3.
– PlayerStatusControl: Lưu trữ thông số người chơi, như sức mạnh đạn,
thời gian hồi chiêu, và tốc độ di chuyển, đồng thời xử lý logic cập nhật
thông số dựa trên dữ liệu từ UI. Component này điều chỉnh hiệu suất của
PlayerAction, ví dụ, tăng sát thương bắn ở màn 3 để đối phó với boss cuối.
– StatusProfile: Quản lý dữ liệu giao diện người dùng, lưu trữ các giá trị
như thông số hiện tại của người chơi, và truyền chúng đến PlayerStatus-
Control. Component này hiển thị và cập nhật thông tin trên UI, như sức
khỏe hoặc thông số, ở cả ba màn.
```
– VirtualButton: Xử lý các nút bấm trong UI, lưu trữ trạng thái nút (như
```
```
nhấn hay không nhấn) và thực hiện logic tương tác, ví dụ, kích hoạt thay
```
đổi thông số, quay về menu, hoặc khởi động lại màn chơi. Component này
40
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
cho phép người chơi sử dụng cử chỉ tay để tương tác với UI, được sử dụng
xuyên suốt các màn.
– PlayerShipAction: Lưu trữ trạng thái hành động phi thuyền vũ trụ, như
hướng di chuyển hoặc góc xoay, và xử lý các hành động như di chuyển
```
(trỏ ngón trỏ), xoay (úp lòng bàn tay), và bắn (trỏ ngón trỏ tay phải).
```
Component này tích hợp với StaticHandGesture để điều khiển phi thuyền
ở màn 2, đảm bảo trải nghiệm VR mượt mà.
```
– SpaceShipController: Quản lý trạng thái phi thuyền (vị trí, vận tốc) và
```
thực hiện logic điều khiển phi thuyền dựa trên PlayerShipAction. Com-
ponent này cho phép phi thuyền di chuyển linh hoạt trong không gian, né
tránh SpaceFighterShip hoặc thiên thạch ở màn 2.
– ShipHealthController: Lưu trữ sức khỏe phi thuyền và xử lý logic trừ
máu khi bị tấn công bởi SpaceFighterShip hoặc va chạm thiên thạch, đồng
thời xác định trạng thái hết máu. Component này tích hợp với GameMan-
ager để xử lý thất bại ở màn 2.
```
– EnemyControl: Quản lý trạng thái bốn loại kẻ địch (HoverBot, Turret,
```
```
SpaceFighterShip, boss cuối) và thực hiện logic tấn công, sử dụng dữ
```
liệu từ DetectionModule để nhắm mục tiêu. Component này điều khiển di
chuyển lơ lửng của HoverBot hoặc tấn công nhanh của SpaceFighterShip.
```
– DetectionModule: Lưu trữ thông tin mục tiêu (như vị trí AimObject trong
```
```
layer Player) và xử lý logic phát hiện trong phạm vi DetectionRange và
```
AttackRange. Component này cho phép HoverBot, Turret, SpaceFighter-
Ship, và boss cuối nhắm chính xác người chơi hoặc phi thuyền.
– LazerAttackController: Quản lý trạng thái tấn công laser của boss cuối,
thực hiện logic bắn dựa trên mục tiêu từ DetectionModule. Component
này được sử dụng ở màn 3.
```
– TimelineShip: Lưu trữ thông tin diễn hoạt (như thời điểm bắt đầu) và xử
```
lý cảnh rơi phi thuyền ở đoạn mở đầu, tạo trải nghiệm nhập vai cho người
chơi trước khi bắt đầu màn 1.
– UpperCharacter: Quản lý trạng thái diễn hoạt nâng người chơi ở các
cảnh tương ứng, tăng tính hấp dẫn cho trò chơi.
5.1.2 Thiết kế tổng quan
Mã nguồn được tổ chức thành bốn gói chính: Enemy_Package, Manager_Package,
Player_Package, và SpaceShip_Package, đảm bảo cấu trúc rõ ràng, giảm thiểu xung
đột tên, và tăng tính bảo trì.
41
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
5.1
Hình 5.1: Biểu đồ phụ thuộc gói của hệ thống
```
Enemy_Package: Quản lý hành vi di chuyển và tấn công của bốn loại kẻ địch
```
```
(HoverBot, Turret, SpaceFighterShip, boss cuối) thông qua các script như Enemy-
```
Control, DetectionModule, LazerAttackController. Gói này phụ thuộc vào Player_Package
và SpaceShip_Package để phát hiện mục tiêu.
```
Manager_Package: Chứa GameManager và các script quản lý trạng thái trò
```
chơi, chuyển màn, hiển thị UI và hoạt ảnh phi thuyền. Gói này trao đổi dữ liệu giữa
UI, nhân vật và phi thuyền, phụ thuộc vào Player_Package và SpaceShip_Package.
```
SpaceShip_Package: Bao gồm các script điều khiển phi thuyền ở màn 2 như
```
SpaceFighterAimController, SpaceShipController, ShipHealthController, nhận dữ
liệu điều khiển từ Player_Package để thực hiện thao tác theo cử chỉ tay.
```
Player_Package: Quản lý nhân vật người chơi, xử lý cử chỉ tay, máu và trạng
```
thái, đồng thời cung cấp dữ liệu cho các gói khác như SpaceShip_Package.
42
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
5.1.3 Thiết kế chi tiết gói
a, Player Package
Hình 5.2: Thiết kế chi tiết của Player Package
Đây là gói quan trọng nhất giúp người chơi điều khiển nhân vật và tương tác với
mọi yếu tố trong game. Lớp PlayerStatusController giữ vai trò trung tâm, quản lý
trạng thái tổng thể của người chơi, bao gồm dữ liệu sức khỏe và thông tin đầu vào.
PlayerHealthController chịu trách nhiệm xử lý logic về sát thương và trạng thái
sống/chết của người chơi, đồng thời cung cấp thông tin sức khỏe cho PlayerStatus-
Controller để hỗ trợ các quyết định trong game.
PlayerActions điều khiển các hành động của nhân vật ở chế độ đi bộ, bao gồm di
43
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
chuyển theo hướng tay trái, bắn, kích hoạt lá chắn và dịch chuyển bằng cách chiếu
tia xác định vị trí đích.
PlayerShipActions quản lý hành động của người chơi khi điều khiển phi thuyền
vũ trụ, gửi các tương tác đến SpaceshipController để thực hiện di chuyển theo
hướng dựa trên cử chỉ tay hoặc bắn. Đồng thời, PlayerShipActions gửi dữ liệu đến
SpaceFighterAimController để điều khiển trạng thái ngắm bắn của phi thuyền.
b, SpaceShip Package
Hình 5.3: Thiết kế chi tiết của SpaceShip Package
Đây là gói tập trung vào các tương tác vật lý mà phi thuyền vũ trụ thực hiện sau
khi nhận được dữ liệu từ Player Package.
Lớp SpaceshipController chịu trách nhiệm điều khiển phi thuyền vũ trụ, nhận
dữ liệu từ các lớp thuộc Player Package để thực hiện các hành động như di chuyển
```
theo hướng chỉ định, xoay (yaw, pitch, roll) dựa trên cử chỉ tay, hoặc bắn thông
```
qua component Triggerable. Lớp này sử dụng Rigidbody để áp dụng lực và mô-
44
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
men xoắn, đảm bảo chuyển động vật lý chính xác, và hỗ trợ tăng tốc về phía trước
```
(boost) với lực cố định.
```
Lớp SpaceFighterAimControl hỗ trợ tính năng nhắm bắn tự động, tìm kiếm kẻ
```
thù trong một bán kính xác định (dựa trên LayerMask) và xoay phi thuyền về phía
```
```
mục tiêu gần nhất, sử dụng phép toán góc (Vector3.Angle) để xác định hướng. Lớp
```
```
này cung cấp trạng thái nhắm bắn (IsAiming) để SpaceshipController điều chỉnh
```
logic di chuyển.
Lớp EnterVehicle quản lý quá trình chuyển đổi trạng thái của người chơi giữa
chế độ đi bộ và điều khiển phi thuyền, kích hoạt hoặc vô hiệu hóa các hành động
của PlayerShipActions dựa trên trạng thái lên/xuống phi thuyền.
c, Manager Package
Hình 5.4: Thiết kế chi tiết của Manager Package
Manager Package là gói quan trọng để hỗ trợ người chơi điều khiển nhân vật và
quản lý các tương tác trong trò chơi.
Lớp GameManager đóng vai trò trung tâm, chịu trách nhiệm quản lý trạng thái
toàn cục của trò chơi, như chế độ chơi và các quy tắc tổng thể. Lớp này cho phép
quản lý nhiều nút ảo và nhiều đối tượng chuyển tiếp màn hình để điều phối các
chức năng giao diện.
45
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
Lớp VirtualButton xử lý các nút ảo trong giao diện, cung cấp vị trí tương tác cho
người chơi để thực hiện các hành động như điều chỉnh trạng thái hoặc gửi lệnh.
LớpUIStatusProfile quản lý giao diện trạng thái, nhận dữ liệu từ PlayerStatus-
Controller trong package Player để cập nhật thông tin như sức khỏe hoặc chế độ
chơi, và hỗ trợ quyết định kết thúc màn chơi khi cần.
Lớp ChangeScreenManager quản lý việc chuyển đổi màn hình hoặc giao diện,
nhận dữ liệu từ PlayerActions trong package Player để thực hiện chuyển màn hoặc
hiển thị các đoạn cutscene động dựa trên trạng thái và vị trí của người chơi.
Lớp UpperCharacter và TimeLineShip là các lớp để tạo realtime cutscene, về cơ
bản chỉ là thay đổi chuyển động của các đối tượng khi đạt một điều kiện nhất định
nào đó.
d, Enemy Package
Hình 5.5: Thiết kế chi tiết của Enemy Package
Enemy Package chứa các lớp hỗ trợ thực hiện hành vi của kẻ thù trong trò chơi.
Lớp DetectionModule đóng vai trò trung tâm, chịu trách nhiệm phát hiện người
46
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
chơi để cung cấp thông tin cho các hành động của kẻ thù. Lớp này sử dụng Play-
erActions trong package Player, truy xuất dữ liệu như vị trí hoặc trạng thái hành
động của người chơi để hỗ trợ hệ thống AI trong việc theo dõi và xác định mục tiêu
tấn công.
Lớp LazerAttackController quản lý hành vi tấn công của boss, đối với boss trong
trò chơi sẽ xử dụng lối tấn công chính là tấn công bằng lazer, lớp này sử dụng dữ
liệu từ DetectionModule để xác định vị trí người chơi và thực hiện các đòn tấn công
lazer chính xác.
Lớp EnemyController điều phối hành vi tổng thể của kẻ thù, như di chuyển hoặc
phản ứng với người chơi, cũng phụ thuộc vào DetectionModule để nhận thông tin
về mục tiêu và đưa ra các quyết định chiến thuật. Enemy Package phối hợp với
package Player để đảm bảo kẻ thù có thể phát hiện và tương tác với người chơi, tạo
nên các tình huống đối kháng trong trò chơi.
47
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
5.2 Thiết kế chi tiết
Hình 5.6: Các lớp quan trọng trong việc điều khiển và vận hành trò chơi
48
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
Bốn lớp cốt lõi trong hệ thống VR Gesture, bao gồm StaticHandGesture, Play-
erActions, PlayerShipActions, và SpaceshipController, được thiết kế để truyền sự
kiện thông qua mẫu thiết kế Observer, sử dụng cơ chế UnityEvent nhằm quản
lý và xử lý các sự kiện một cách hiệu quả, như minh họa trong Hình 5.6. Cụ
thể, lớp StaticHandGesture đăng ký các sự kiện như gesturePerformed và ges-
tureEnded thông qua UnityEvent, cho phép các lớp khác như PlayerActions và
PlayerShipActions lắng nghe và phản hồi khi có thay đổi. Khi một sự kiện đã được
```
đăng ký (như phát hiện cử chỉ tay tĩnh) và được kích hoạt bởi StaticHandGesture
```
```
thông qua phương thức m_GesturePerformed.Invoke(), thông báo sẽ được gửi đến
```
PlayerActions và PlayerShipActions. Sau khi nhận thông báo, PlayerActions hoặc
PlayerShipActions sẽ thực hiện các hành động tương tác tương ứng với cử chỉ,
chẳng hạn như di chuyển nhân vật, bắn, hoặc điều khiển phi thuyền vũ trụ, bằng
cách cập nhật trạng thái tay và gọi các phương thức xử lý hành động. Trong khi đó,
PlayerShipActions tương tác trực tiếp với SpaceshipController bằng cách gọi các
phương thức như HandlePoint hoặc HandleFire để thực hiện các lệnh điều khiển
phi thuyền.
Hình 5.7: Luồng thực hiện khi người chơi điều khiển nhân vật chính
Luồng hoạt động của PlayerActions được thể hiện trong Hình 5.7, tập trung vào
chế độ đi bộ của người chơi. Khi nhận tín hiệu từ StaticHandGesture qua sự kiện
gesturePerformed, PlayerActions cập nhật trạng thái tay bằng cách thay đổi giá
trị của rightHandStateName và leftHandStateName trong phương thức Update. Cụ
thể, nếu rightHandStateName được đặt thành "Firing", phương thức HandleStates
sẽ gán rightHandState thành Firing và gọi hàm Firing để thực hiện hành động bắn,
trong đó dữ liệu count tăng lên và trạng thái cooldown được kiểm tra để quyết
49
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
```
định có bắn hay không; nếu rightHandStateName là "Shield", HandleStates gán
```
rightHandState thành Shield và gọi Shield để kích hoạt lá chắn, thay đổi trạng
thái hiển thị của ShieldModel. Tương tự, nếu leftHandStateName được đặt thành
"MoveDirectionPoint", HandleStates gán leftHandState thành MoveDirectionPoint
và gọi MoveDirectionPoint để di chuyển nhân vật theo hướng tay trái, cập nhật vị
trí của playerTransform dựa trên leftHandTransform.forward. Nếu leftHandState-
Name là "Teleport_Aim", HandleStates gọi Teleport_Aim để xác định vị trí dịch
chuyển, sau đó Teleport_Start được gọi để cập nhật vị trí nhân vật và kích hoạt hiệu
ứng.
Hình 5.8: Luồng thực hiện khi người chơi điều khiển phi thuyền
Luồng hoạt động của PlayerShipActions được mô tả trong Hình 5.8, áp dụng khi
người chơi điều khiển phi thuyền vũ trụ. Sau khi nhận tín hiệu từ StaticHandGes-
ture qua gesturePerformed, PlayerShipActions cập nhật trạng thái tay trong phương
thức Update bằng cách thay đổi rightHandStateName và leftHandStateName. Nếu
rightHandStateName được đặt thành "Firing", HandleStates gán rightHandState
```
thành Firing và gọi Firing, sau đó gọi SpaceshipController.HandleFire(true) để
```
thực hiện hành động bắn, thay đổi trạng thái của triggerable trong SpaceshipCon-
troller. Nếu rightHandStateName là "StopFiring", HandleStates gọi StopFiring và
```
SpaceshipController.HandleFire(false) để ngừng bắn. Với leftHandStateName, nếu
```
được đặt thành "PointDirectionPoint", HandleStates gán leftHandState thành Point-
DirectionPoint và gọi PointDirectionPoint, sau đó gọi HandlePoint để di chuyển
phi thuyền theo hướng tay, cập nhật lực vật lý của Rigidbody trong SpaceshipCon-
troller. Nếu leftHandStateName là "PalmDirectionPoint", HandleStates gọi PalmDi-
```
rectionPoint và SpaceshipController.HandlePalm(leftHandPoke) để roll phi thuyền.
```
Nếu là "ThumbUpDirection" hoặc "ThumbDownDirection", HandleStates lần lượt
gọi ThumbUpDirection hoặc ThumbDownDirection, sau đó gọi HandleThumbUp
hoặc HandleThumbDown để pitch phi thuyền lên hoặc xuống.
50
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
5.3 Xây dựng ứng dụng
5.3.1 Thư viện và công cụ sử dụng
Mục đích Công cụ Địa chỉ URL
Code editor Visual Studio Code 2019 visualstudio.microsoft.com
Game Engine Unity Engine 2022.3.501f1 unity.com
XR Hands & Gesture XR Hands 1.4.3 com.unity.xr.hands@1.4
Bảng 5.1: Danh sách thư viện và công cụ sử dụng
5.3.2 Kết quả đạt được
Quá trình phát triển tạo ra hệ thống trò chơi có thể chơi được. Hệ thống gồm 4
gói chính chưa logic của trò chơi, gồm Player Package chứa các logic điều khiển
người chơi và kích hoạt các hành động khi nhận diện cử chỉ, gói này có thể tái sử
dụng ở bất cứ trò chơi nào sử dụng cơ chế điều khiển bằng cử chỉ. Gói SpaceShip
Package chứa logic điều khiển phi thuyền, có thể tái sử dụng cho các trò chơi thuộc
loại điều khiển phi thuyền không gian. Gói Manager Package chưa logic của màn
chơi và các nút điều khiển, về mặt điều khiển UI, logic của gói này có thể tái sử
dụng cho bất cứ trò chơi VR nào. Gói Enemy Package chứa logic điều khiển kẻ
địch.
Bảng 5.2 thể hiện thông tin chi tiết các gói.
Package Name No. of classes Lines of codes Package size
Player Package 4 607 23.9KB
SpaceShip Package 5 404 18KB
Manager Package 11 390 16KB
Enemy Package 3 710 28KB
Bảng 5.2: Package details
5.4 Sản phẩm
Phần này sẽ giúp người chơi hiểu rõ hơn về các hoạt động, chức năng chính và
trải nghiệm thực tế trong trò chơi, đồng thời cung cấp cái nhìn tổng quan về hành
trình phiêu lưu, các thử thách và những điểm đặc sắc mà trò chơi mang lại.
Ngay khi bắt đầu, người chơi được đưa vào một không gian nhà chính rộng lớn,
hiện đại, đóng vai trò là căn cứ khởi đầu của toàn bộ hành trình. Khung cảnh tại
đây được thiết kế yên bình, ánh sáng dịu nhẹ, kết hợp với các chi tiết kiến trúc công
nghệ cao, tạo cảm giác an toàn và thân thiện cho người mới. Trong giai đoạn này,
người chơi có thể tự do quan sát, làm quen với thao tác di chuyển, ngắm nhìn cảnh
```
vật xung quanh và chuẩn bị tinh thần cho những thử thách phía trước (hình 5.9).
```
51
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
Đây cũng là nơi người chơi tiếp nhận các hướng dẫn cơ bản về điều khiển, sử dụng
vũ khí và kỹ năng phòng thủ, giúp làm quen với hệ thống gameplay mà không bị
áp lực từ kẻ địch.
Hình 5.9: Khung cảnh nhà chính khi trò chơi bắt đầu.
Bầu không khí yên bình nhanh chóng bị phá vỡ khi một phi thuyền của kẻ địch
bất ngờ rơi xuống gần căn cứ, kéo theo sự xuất hiện của các Hover Bot – những
```
robot bay nhỏ, linh hoạt, được thả ra từ phi thuyền địch (hình 5.10). Hover Bot là
```
đối thủ lý tưởng để người chơi luyện tập khả năng bắn súng, sử dụng khiên phòng
thủ và rèn luyện phản xạ né tránh. Các đợt tấn công ban đầu này không quá khó,
giúp người chơi từng bước làm quen với nhịp độ chiến đấu, đồng thời cảm nhận rõ
ràng sự chuyển biến từ trạng thái an toàn sang nguy hiểm, tạo động lực khám phá
tiếp các thử thách tiếp theo.
Hình 5.10: Hover Bot bị rơi ra từ phi thuyền.
Tiếp tục tiến vào khu vực phi thuyền vũ trụ, người chơi sẽ đối mặt với Turret
Bot – loại robot phòng thủ cố định, thường được bố trí ở các vị trí chiến lược như
```
gần sông, lối đi hoặc các khu vực trọng yếu (hình 5.11). Turret Bot sở hữu hỏa lực
```
52
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
mạnh và khả năng phát hiện mục tiêu từ xa, buộc người chơi phải vận dụng kỹ năng
di chuyển, tận dụng các vật cản tự nhiên để ẩn nấp và lên kế hoạch tấn công hợp lý.
Sự xuất hiện của Turret Bot không chỉ tăng độ khó cho trò chơi mà còn giúp người
chơi rèn luyện tư duy chiến thuật, kết hợp giữa phòng thủ và tấn công một cách linh
hoạt.
Hình 5.11: Turret Bot cản đường người chơi.
Sau khi vượt qua các đợt tấn công, người chơi sẽ tiếp cận được khối cầu năng
```
lượng trung chuyển (hình 5.12), đây là thiết bị hỗ trợ di chuyển lên các khu vực cao
```
hơn, cụ thể là tòa tháp lớn nơi đặt phi thuyền. Việc sử dụng khối cầu năng lượng
không chỉ giúp người chơi làm quen với các cơ chế di chuyển đặc biệt mà còn tạo
cảm giác mới lạ, tăng tính tương tác với môi trường trong game.
Hình 5.12: Khối cầu năng lượng trung chuyển.
Khi vào bên trong phi thuyền, người chơi sẽ điều khiển phi thuyền tiến vào lỗ
```
hổng không gian, mở ra màn chơi thứ hai với bối cảnh vũ trụ rộng lớn (hình 5.13).
```
Đây là bước chuyển tiếp quan trọng, đánh dấu sự thay đổi lớn về môi trường và thử
thách, khi người chơi rời khỏi hành tinh quen thuộc để bước vào không gian vô tận
53
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
đầy bí ẩn.
Hình 5.13: Cổng không gian để di chuyển giữa hành tinh xanh và bên ngoài vũ trụ.
Màn hai mở ra một không gian vũ trụ vô tận, nơi người chơi có thể quan sát các
thiên thể, phi thuyền vũ trụ của kẻ địch và cổng không gian dẫn tới hành tinh tiếp
```
theo (hình 5.14). Trong môi trường không trọng lực này, người chơi phải khéo léo
```
điều khiển phi thuyền, né tránh các thiên thạch, đồng thời có thể lựa chọn tấn công
các phi thuyền địch để tích lũy điểm nâng cấp kỹ năng. Sự đa dạng về thử thách và
môi trường giúp tăng chiều sâu cho gameplay, đồng thời mang lại cảm giác phiêu
lưu, chinh phục không gian thực thụ.
Hình 5.14: Không gian vũ trụ vô tận.
Những trận chiến trong không gian, như minh họa ở hình 5.15, đòi hỏi người
chơi phải phối hợp linh hoạt giữa di chuyển, né tránh và tấn công. Việc đối đầu với
các phi thuyền vũ trụ của kẻ địch không chỉ giúp người chơi rèn luyện kỹ năng điều
khiển phi thuyền mà còn mang lại phần thưởng xứng đáng dưới dạng điểm nâng
cấp, mở ra nhiều lựa chọn phát triển sức mạnh cho nhân vật.
54
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
Hình 5.15: Trận chiến trong không gian giữa người chơi và phi thuyền vũ trụ.
Sau khi vượt qua những trận chiến căng thẳng với các phi thuyền vũ trụ của kẻ
địch trong không gian, người chơi sẽ tiếp tục hành trình tiến gần đến hành tinh
chết – nơi ẩn chứa những bí ẩn và nguy hiểm lớn nhất của trò chơi. Trên đường đi,
người chơi có thể quan sát thấy cổng không gian khổng lồ của kẻ địch như trong
hình 5.16, đây là một công trình mang đậm dấu ấn công nghệ và đóng vai trò như
cửa ngõ cuối cùng dẫn tới vùng đất hoang tàn phía trước. Việc tiếp cận cổng không
gian này không chỉ đòi hỏi người chơi phải khéo léo điều khiển phi thuyền, né
tránh các vật thể trôi nổi và mối nguy từ phi thuyền địch, mà còn cần sự chuẩn bị
kỹ lưỡng về kỹ năng cũng như trang bị để sẵn sàng đối mặt với thử thách lớn nhất
đang chờ đợi phía sau.
Hình 5.16: Cổng không gian bên ngoài hành tinh chết.
Màn ba đưa người chơi đến một hành tinh chết với khung cảnh hoang tàn, đổ nát
```
(hình 5.17). Tại đây, người chơi sẽ phải vận dụng tối đa kỹ năng di chuyển, sử dụng
```
các tảng đá lớn để luyện tập dịch chuyển tức thời và tìm đường tiếp cận khu vực
của trùm cuối. Không gian u ám, tàn tích và robot lang thang tạo nên bầu không
55
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
khí căng thẳng, báo hiệu trận chiến quyết định sắp diễn ra.
Hình 5.17: Khung cảnh hành tinh chết.
Để tiếp cận khu vực của trùm cuối, người chơi có thể lựa chọn nhiều con đường
khác nhau. Một số lối đi là các hẻm đá hẹp, đòi hỏi phải di chuyển khéo léo như
hình 5.18 đã mô tả. Ngoài ra, người chơi còn có thể sử dụng kỹ năng dịch chuyển
tức thời để nhảy qua các tảng đá lớn, rút ngắn quãng đường. Chính sự đa dạng trong
cách tiếp cận này không chỉ giúp mỗi lượt chơi trở nên mới mẻ mà còn khuyến khích
người chơi sáng tạo, thử nghiệm các chiến thuật khác nhau nhằm tối ưu hóa khả
năng sinh tồn và chiến thắng trong môi trường đầy thử thách.
Hình 5.18: Lối đi vào màn đánh trùm cuối.
Cao trào của trò chơi là trận chiến với trùm cuối – một kẻ địch sở hữu khả năng
phóng tia năng lượng cực mạnh. Người chơi phải vận dụng tối đa kỹ năng dịch
```
chuyển, né tránh và tấn công linh hoạt để vượt qua thử thách này (hình 5.19). Chiến
```
thắng trùm cuối cũng là lúc người chơi hoàn thành toàn bộ hành trình chinh phục
thế giới ảo, khẳng định bản lĩnh và kỹ năng của mình trong môi trường thực tế ảo
đầy kịch tính và cuốn hút.
56
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
Hình 5.19: Trận chiến giữa người chơi và trùm cuối.
5.5 Triển khai
Astral Reclaim được phát triển và triển khai chủ yếu trên nền tảng Meta Quest
2, một thiết bị VR độc lập với khả năng xử lý cử chỉ tay và hiệu suất cao, phù hợp
cho trải nghiệm bắn súng kết hợp phiêu lưu. Ngoài ra, trò chơi được thiết kế để
tương thích với các nền tảng VR khác như Pico, tận dụng các API chuẩn của Unity
XR để đảm bảo khả năng chuyển đổi linh hoạt. Quy trình triển khai bao gồm cấu
hình môi trường phát triển, tối ưu hóa hiệu suất, và kiểm thử trên thiết bị thực tế,
nhằm mang lại trải nghiệm VR mượt mà qua ba màn chơi.
5.5.1 Môi trường phát triển và triển khai
Trò chơi được phát triển trên nền tảng Unity 2022.3 LTS, sử dụng các công cụ
chính bao gồm Unity Editor để xây dựng và tích hợp các script MonoBehaviour,
Visual Studio để chỉnh sửa và gỡ lỗi mã nguồn C#, cùng với XR Interaction Toolkit
để hỗ trợ các thao tác tương tác trong môi trường thực tế ảo. Để đảm bảo khả năng
tương thích với nhiều thiết bị, dự án sử dụng Oculus Integration SDK cho Meta
Quest 2 và OpenXR Plugin để mở rộng sang các nền tảng VR khác như Pico. Khi
triển khai trên thiết bị Pico, cần bổ sung thêm Pico Unity Integration SDK.
Quá trình kiểm thử và phát triển chủ yếu được thực hiện trên thiết bị Meta Quest
2 với cấu hình phần cứng như trình bày ở Bảng 5.3 dưới đây:
Tên cấu hình Thông số
Hệ điều hành Android 10
CPU Qualcomm Snapdragon XR2
RAM 6GB
Bộ nhớ 128GB
Độ phân giải 1832x1920
Bảng 5.3: Thông số cấu hình thiết bị triển khai trò chơi
57
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
5.5.2 Quy trình triển khai và cài đặt
Để triển khai trò chơi lên thiết bị Meta Quest 2, ứng dụng được xuất bản dưới
dạng tệp APK thông qua chế độ Android Build Settings với kiến trúc ARM64.
Quá trình cài đặt nội bộ sử dụng nền tảng SideQuest và chế độ Sideload để tải
APK lên thiết bị. Đối với thiết bị Pico, trò chơi được đóng gói và phân phối qua
Pico Developer Platform với quy trình build tương tự.
Để tái tạo môi trường phát triển, người dùng cần cài đặt Unity 2022.3 LTS, các
```
SDK tương ứng (Oculus Integration, OpenXR hoặc Pico SDK), và đảm bảo thiết
```
bị VR hỗ trợ hand tracking hoặc controller truyền thống. Mã nguồn được tổ chức
```
thành các gói riêng biệt cho từng chức năng (Player, Enemy, UI, Environment),
```
thuận tiện cho việc bảo trì và mở rộng.
5.5.3 Tối ưu hóa hiệu suất
Trong quá trình phát triển, nhiều biện pháp tối ưu hóa đã được áp dụng để đảm
bảo trò chơi vận hành mượt mà trên các thiết bị VR phổ thông. Cụ thể, số lượng đa
giác trong các mô hình 3D như HoverBot, Turret và phi thuyền vũ trụ được giảm
```
thiểu tối đa; texture sử dụng định dạng nén để tiết kiệm bộ nhớ; các vật thể môi
```
trường ở màn 1 và 3 được tối giản nhằm duy trì tốc độ khung hình ổn định ở mức
```
50-60 FPS. Hệ thống giao diện người dùng (UI) cũng được tối ưu bằng cách sử
```
dụng canvas tĩnh, chỉ cập nhật khi có thay đổi về trạng thái sức khỏe hoặc điểm
nâng cấp, giúp giảm tải cho GPU, đặc biệt trong các pha chiến đấu với boss cuối.
5.5.4 Kiểm thử và đánh giá thực tế
Quy trình kiểm thử được tiến hành toàn diện trên Meta Quest 2, bao gồm kiểm
thử chức năng, kiểm thử hiệu suất và kiểm thử tương thích. Về chức năng, các
module như StaticHandGesture, PlayerAction, PlayerShipAction được kiểm tra để
đảm bảo nhận diện đúng các cử chỉ tay và phản hồi chính xác với hành động của
người chơi. DetectionModule đảm bảo kẻ địch như HoverBot, Turret và boss cuối
luôn nhận diện và tấn công đúng mục tiêu. Quản lý chuyển màn và giao diện người
dùng được kiểm tra thông qua GameManager.
Về hiệu suất, tốc độ khung hình được đo lường ở các màn chơi, đặc biệt khi xuất
hiện nhiều phi thuyền địch hoặc trong các pha giao tranh căng thẳng với boss cuối.
Kết quả kiểm thử cho thấy trò chơi duy trì ổn định ở mức 50-60 FPS trên Meta
Quest 2. Ngoài ra, trò chơi cũng được kiểm tra trên Meta Quest 3 và các thiết bị
Pico, với các điều chỉnh nhỏ về UI và điều khiển để đảm bảo trải nghiệm nhất quán.
58
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
5.5.5 Thống kê và phản hồi thử nghiệm
Trong quá trình thử nghiệm nội bộ, trò chơi đã được cài đặt và trải nghiệm bởi
nhóm phát triển và một số người dùng thử. Thời gian phản hồi của các thao tác
chính đều dưới 50 ms, đảm bảo cảm giác mượt mà và tức thời. Người dùng đánh
giá cao tính nhập vai của hệ thống cử chỉ tay và giao diện tối giản, đồng thời ghi
nhận hiệu suất ổn định ngay cả trong các tình huống chiến đấu đông kẻ địch. Một
số phản hồi góp ý về giao diện và độ nhạy của cử chỉ đã được tiếp thu và điều chỉnh
trong các phiên bản cập nhật tiếp theo.
Nhìn chung, quá trình triển khai, kiểm thử và tối ưu hóa đã giúp trò chơi vận
hành ổn định trên các thiết bị VR phổ thông, sẵn sàng cho việc mở rộng thử nghiệm
với số lượng người dùng lớn hơn trong tương lai.
59
CHƯƠNG 6. CÁC GIẢI PHÁP VÀ ĐÓNG GÓP NỔI BẬT
Trong chương trước, các nội dung về thiết kế, kiểm thử và triển khai trò chơi
Astral Reclaim đã được trình bày. Trong chương này, các đóng góp nổi bật của đồ
án được mô tả, bao gồm việc thiết kế hệ thống nhận diện cử chỉ tay để điều khiển
nhân vật và phi thuyền vũ trụ, cùng với các thuật toán điều khiển phi thuyền vũ trụ.
6.1 Xây dựng hệ thống điều khiển nhân vật bằng cử chỉ
6.1.1 Đặt vấn đề
Trò chơi Astral Reclaim yêu cầu hệ thống điều khiển cử chỉ tay để tạo trải
nghiệm VR độc đáo trong thể loại bắn súng kết hợp phiêu lưu. Các giải pháp
nhận diện cử chỉ tay có sẵn trong Unity, như XR Interaction Toolkit, chỉ hỗ trợ cử
chỉ cơ bản, không đáp ứng yêu cầu nhận diện và ánh xạ hành động phức tạp như di
chuyển, lao nhanh, bắn, chắn đạn, dịch chuyển tức thời ở màn 1, 3, hoặc điều khiển
phi thuyền ở màn 2. Thách thức chính gồm:
```
• Nhận diện chính xác các cử chỉ tay (trỏ ngón, mở bàn tay, giơ ngón cái, giơ
```
```
ngón trỏ).
```
• Ánh xạ cử chỉ thành hành động nhanh, trực quan.
6.1.2 Giải pháp
Hệ thống nhận diện cử chỉ tay được phát triển thông qua lớp StaticHandGesture
và lớp điều khiển PlayerAction, PlayerShipAction trong gói Player_Package.
a, Nhận diện cử chỉ tay
StaticHandGesture nhận dữ liệu từ XRHandTracking, phân tích vị trí ngón tay,
góc bàn tay, ánh xạ thành cử chỉ:
```
• Trỏ ngón tay: Di chuyển nhân vật (màn 1, 3) hoặc phi thuyền (màn 2).
```
```
• Mở bàn tay trái: Lao nhanh (màn 1, 3).
```
```
• Mở bàn tay phải: Chắn đạn (màn 1, 3).
```
```
• Giơ ngón cái: Dịch chuyển tức thời (màn 1, 3), hướng lên/xuống (màn 2).
```
```
• Giơ ngón trỏ tay phải: Bắn (màn 1, 3, 2).
```
Thuật toán nhận diện so sánh dữ liệu tay thời gian thực với mẫu cử chỉ, sử dụng
độ lệch:
```
D(Pc, Pm) =
```
nX
```
i=1
```
```
(wp · |pc,i − pm,i| + wr · angle(rc,i, rm,i)) (6.1)
```
60
CHƯƠNG 6. CÁC GIẢI PHÁP VÀ ĐÓNG GÓP NỔI BẬT
trong đó:
• Pc: Dữ liệu tay hiện tại, Pm: Mẫu cử chỉ.
```
• pc,i, pm,i: Vị trí khớp (Vector3).
```
```
• rc,i, rm,i: Xoay khớp (Quaternion).
```
• wp, wr: Trọng số.
```
• angle: Góc xoay (radian).
```
Cử chỉ có độ lệch nhỏ nhất được truyền đến PlayerAction hoặc PlayerShipAction.
b, Ánh xạ hành động trong PlayerAction
```
PlayerAction ánh xạ cử chỉ thành hành động ở màn 1, 3, dùng delegate (Hand-
```
```
State):
```
```
• Di chuyển (MoveDirectionPoint): Vector di chuyển dựa trên hướng tay trái:
```
```
⃗v =⃗ fleftHand · (sbase + sbonus) · ∆t (6.2)
```
⃗v.y = 0, cập nhật playerTransform.position.
```
• Lao nhanh (DashDirectionPoint): Tăng tốc (20 đơn vị/s) trong 0.2 giây:
```
```
⃗v dash =⃗ fleftHand · 20 · ∆t (6.3)
```
```
Hồi chiêu (Dash Cooldown, mặc định 2 giây) kiểm soát tần suất.
```
```
• Bắn (Firing): Kích hoạt bắn qua WeaponController nếu count < maxCount
```
```
(300), tăng count mỗi khung hình, hồi chiêu khi count = 0.
```
```
• Chắn đạn (Shield): Kích hoạt/tắt ShieldModel dựa trên trạng thái mở bàn tay
```
phải.
```
• Dịch chuyển tức thời (Teleport_Aim, Teleport_Start): Raycast từ leftHand-
```
```
DirectTransform xác định điểm đích (maxDistance = 100), di chuyển trans-
```
form.position đến điểm đích, kích hoạt hiệu ứng hạt trong 2 giây.
```
PlayerShipAction áp dụng tương tự cho phi thuyền ở màn 2 (di chuyển, xoay,
```
```
bắn, hướng lên/xuống).
```
6.1.3 Kết quả đạt được
Hệ thống nhận diện cử chỉ tay đạt các kết quả nổi bật:
```
• Nhận diện chính xác các cử chỉ (trỏ ngón, mở bàn tay, giơ ngón cái, giơ ngón
```
```
trỏ), phản hồi trong 50ms trên Meta Quest 2.
```
61
CHƯƠNG 6. CÁC GIẢI PHÁP VÀ ĐÓNG GÓP NỔI BẬT
• Hành động trực quan, mượt mà ở màn 1, 2, 3, với thuật toán di chuyển, lao
nhanh, bắn, chắn đạn, dịch chuyển tức thời.
```
• Linh hoạt, dễ mở rộng thêm cử chỉ phức tạp (xoay cổ tay, hai tay).
```
Hệ thống cử chỉ tay với thuật toán trong PlayerAction tạo nền tảng vững chắc
cho điều khiển trong Astral Reclaim, mang lại trải nghiệm VR độc đáo.
6.2 Xây dựng hệ thống điều khiển tàu vũ trụ bằng cử chỉ
6.2.1 Đặt vấn đề
Trong trò chơi Astral Reclaim, điều khiển phi thuyền vũ trụ ở màn 2 là một trong
những yếu tố cốt lõi, yêu cầu tích hợp cử chỉ tay để mang lại trải nghiệm VR trực
quan. Hiện tại chưa có giải pháp sẵn có nào giải quyết việc điều khiển phi thuyền
và ánh xạ hiệu quả từ Gesture cũng như thực hiện hỗ trợ phi thuyền nhắm bắn tới kẻ
địch. Điều này đặt ra một thách thức lớn trong việc phát triển gameplay của game.
Các vấn đề chính bao gồm:
```
• Nhận diện cử chỉ tay (trỏ ngón, úp bàn tay, giơ ngón cái) và ánh xạ thành hành
```
động phi thuyền.
• Thiết kế thuật toán điều khiển mượt mà, tích hợp nhắm tự động với hiệu suất
cao.
6.2.2 Giải pháp
Hệ thống điều khiển phi thuyền vũ trụ được phát triển thông qua lớp Spaceship-
Controller và SpaceFighterAimControl trong gói SpaceShip_Package, tích hợp với
PlayerShipAction trong Player _Package để xử lý cử chỉ tay từ StaticHandGesture.
a, Nhận diện và ánh xạ cử chỉ tay
StaticHandGesture nhận dữ liệu từ XRHandTracking, ánh xạ cử chỉ thành hành
động phi thuyền:
• Trỏ ngón tay: Di chuyển phi thuyền theo hướng tay.
```
• Úp bàn tay: Xoay phi thuyền (roll trái/phải).
```
```
• Giơ ngón cái lên/xuống: Nghiêng phi thuyền (pitch lên/xuống).
```
• Giơ ngón trỏ tay phải: Bắn.
```
PlayerShipAction sử dụng delegate (HandState) để ánh xạ cử chỉ thành trạng
```
thái như PointDirectionPoint, PalmDirectionPoint, ThumbUpDirection, Thumb-
DownDirection, Firing, truyền đến SpaceshipController.
62
CHƯƠNG 6. CÁC GIẢI PHÁP VÀ ĐÓNG GÓP NỔI BẬT
b, Thuật toán trong SpaceshipController
SpaceshipController xử lý di chuyển, xoay, và bắn phi thuyền, với các thuật toán
```
sau:
```
```
• Di chuyển (HandlePoint): Tính vector di chuyển dựa trên hướng tay trái
```
```
(leftHandPoke.forward):
```
```
⃗v = (⃗ fhand · zlocal +⃗r ship · xlocal) · s · cos(θ) · ∆t (6.4)
```
trong đó:
```
–⃗ fhand: Hướng tay trái (Vector3).
```
– zlocal, xlocal: Thành phần forward/right trong hệ phi thuyền.
```
– s: Tốc độ (moveSpeed = moveDefaultSpeed + moveBonusSpeed).
```
– θ: Góc lệch giữa phi thuyền và tay.
```
– cos(θ): Hệ số tốc độ (tối thiểu 0.1).
```
```
Nếu góc lệch θ ≤ 15◦ hoặc nhắm tự động (SpaceFighterAimControl.IsAiming),
```
```
bỏ thành phần right (xlocal = 0). Lực di chuyển áp dụng qua Rigidbody.AddForce.
```
```
• Xoay (yaw) trong HandlePoint: Tính góc yaw quanh trục Y:
```
```
α = sign(⃗ fship,⃗ fhand,⃗u ship) · min(sy · ∆t, |θ|) (6.5)
```
trong đó:
–⃗ fship,⃗ fhand: Hướng phi thuyền/tay.
–⃗u ship: Trục up của phi thuyền.
```
– sy: Tốc độ yaw (rotationSpeed, tăng gấp yawSpeedMultiplier = 7 nếu θ ≥
```
```
60◦).
```
Áp dụng mô-men xoắn qua Rigidbody.AddTorque.
```
• Nghiêng (pitch) trong HandleThumbUp/ThumbDown: Tính mô-men xoắn
```
quanh trục X local:
```
⃗τ = ±s r · m · ip ·⃗r ship · ∆t (6.6)
```
trong đó:
```
– sr: Tốc độ xoay (rotationSpeed).
```
```
– m: Hệ số tăng tốc (yawSpeedMultiplier = 7).
```
63
CHƯƠNG 6. CÁC GIẢI PHÁP VÀ ĐÓNG GÓP NỔI BẬT
```
– ip: Cường độ pitch (pitchIntensity = 0.7).
```
–⃗r ship: Trục right của phi thuyền.
```
Dấu ± phụ thuộc vào cử chỉ (lên: âm, xuống: dương). Áp dụng qua Rigid-
```
body.AddTorque.
```
• Xoay (roll) trong HandlePalm: Tính mô-men xoắn quanh trục Z local dựa
```
trên trục Y tay:
```
⃗τ = s r · m · xhand ·⃗ fship · ∆t (6.7)
```
trong đó:
– xhand: Thành phần right của trục Y tay trong hệ phi thuyền.
–⃗ fship: Trục forward của phi thuyền.
```
Roll chỉ kích hoạt nếu |xhand| > rollThreshold (0.1), áp dụng qua Rigidbody.AddTorque.
```
```
• Bắn (HandleFire): Kích hoạt/bỏ kích hoạt bắn qua Triggerable.StartTriggering/StopTriggering
```
khi nhận cử chỉ giơ ngón trỏ tay phải.
```
• Nhắm tự động (SpaceFighterAimControl): Tìm kẻ địch gần nhất trong bán
```
```
kính searchRadius (50 đơn vị):
```
```
target = arg minenemy ∠(⃗fship,⃗ denemy) (6.8)
```
trong đó⃗ denemy là hướng đến kẻ địch. Xoay phi thuyền bằng Quaternion.Lerp
```
với tốc độ rotationSpeed (5 đơn vị/s), dừng nếu góc lệch dưới minAngleThresh-
```
```
old (2 độ).
```
6.2.3 Kết quả đạt được
Hệ thống điều khiển phi thuyền vũ trụ đạt các kết quả nổi bật:
```
• Nhận diện cử chỉ tay chính xác, phản hồi hành động (di chuyển, xoay, bắn)
```
trong 50ms trên Meta Quest 2.
• Điều khiển trực quan, mượt mà ở màn 2, với thuật toán di chuyển, pitch, roll,
và nhắm tự động chống SpaceFighterShip.
```
• Linh hoạt, dễ mở rộng cử chỉ phức tạp (như hai tay).
```
SpaceshipController thể hiện sự hiệu quả trong việc điều khiển phi thuyền khi
sử dụng nhận diện cử chỉ tay. Hệ thống này có thể đặt nền tảng cho sự phát triển
các mô hình điều khiển phương tiện từ lái xe, trực thằng, thuyền và các loại phi
thuyền vũ trụ khác.
64
CHƯƠNG 7. KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN
7.1 Kết luận
Astral Reclaim mang lại một cơ chế điều khiển mới lạ, tạo một phong cách tiên
phong cho thể loạn trò chơi bắn súng VR kết hợp phiêu lưu. Tuy vẫn còn thô sơ,
lối chơi, hiệu ứng và đồ họa sẽ được cải thiện theo thời gian khiến trò chơi hấp dẫn
và cuốn hút hơn.
Trong quá trình tạo ra trò chơi, Player Package và SpaceShip Package đã cung
cấp các tính năng hỗ trợ cho việc điều khiển nhân vật theo cử chỉ tay một cách hiệu
quả.
Bài học rút ra được trong quá trình phát triển trò chơi là quản lí thời gian. Để
phát triển toàn bộ hệ thống và liên kết với nhau, ví dụ như việc liên kết việc điều
khiển player với việc điều khiển phi thuyền và từ điều khiển phi thuyền có thể tương
tác lại với kẻ địch là việc tốn rất nhiều thời gian, việc tinh chỉnh các chi tiết nhỏ như
kẻ địch ở đâu và kẻ địch nhận biết người chơi thế nào cũng là việc cần rất nhiều
thời gian để hoàn thiện. Đối với Enemy Package, chỉ các tính năng cơ bản được
phát triển và cách tấn công của boss cũng chưa đủ thú vị để thu hút người chơi lâu
dài. Vấn đề thời gian này có thể giải quyết bằng cách tập trung vào cấc tính năng
chính được ưu tiên hơn như thiết kế kỹ boss, loại bỏ các tính năng tốn thời gian
nhưng không đem lại hiệu quả cao.
7.2 Hướng phát triển
7.2.1 Lối chơi
Lối chơi hiện tại còn đơn giản, thiếu chiều sâu chiến thuật, đặc biệt ở màn 2 khi
người chơi có thể vượt qua SpaceFighterShip bằng các hành động lặp lại. Cần bổ
sung các yếu tố chiến thuật để tăng tính thử thách và hấp dẫn.
Hệ thống vũ khí cần đa dạng hơn. Hiện tại, nhân vật và phi thuyền sử dụng súng
lục bắn tự động với tốc độ trung bình. Có thể bổ sung các loại vũ khí mới:
• Pháo năng lượng: Gây sát thương lớn cho một mục tiêu, tốc độ bắn chậm.
• Tên lửa khu vực: Gây sát thương trong một vùng, tốc độ bắn rất chậm.
• Chùm tia: Xuyên qua nhiều kẻ địch, yêu cầu tích năng lượng.
Hệ thống phòng thủ của kẻ địch cần cải thiện để tăng độ khó. Hiện tại, Turret và
boss cuối chủ yếu sử dụng đòn laser. Có thể thêm:
• Khiên năng lượng: Bảo vệ HoverBot hoặc Turret trong thời gian ngắn.
65
CHƯƠNG 7. KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN
• Mìn không gian: Gây sát thương khi người chơi hoặc phi thuyền đến gần.
• Trạm tăng cường: Tăng sát thương cho Turret hoặc SpaceFighterShip lân cận.
Vai trò kẻ địch cần được mở rộng để tăng tính chiến thuật. Hiện tại, bốn loại kẻ
địch có hành vi tấn công chung. Có thể bổ sung:
• Kẻ tiên phong: Tấn công nhanh, sát thương thấp, như SpaceFighterShip cải
tiến.
• Kẻ phòng thủ: Bảo vệ Turret hoặc boss cuối, máu cao, sát thương thấp.
• Kẻ quấy rối: Nhắm vào điểm chuyển tiếp, gây áp lực thời gian.
7.2.2 StaticHandGesture
Hiện tại, chỉ hỗ trợ các cử chỉ cơ bản và thực hiện tương đối rõ ràng để hệ thống
có thể nhận biết được. Cần mở rộng để xử lý các trường hợp như cử chỉ gần giống
nhau và các chuỗi cử chỉ liên tiếp.
7.2.3 GameManager
Hệ thống quản lý của GameManager cần hỗ trợ các chế độ chơi mới, như thử
thách thời gian hoặc nhiều người chơi. Hiện tại, nó chỉ xử lý chuyển màn và trạng
thái sức khỏe.
Tích hợp UI qua UIStatusProfile và VirtualButton cần mở rộng để hỗ trợ nút
```
động (như chọn vũ khí) và hiển thị thông tin chi tiết (như số kẻ địch còn lại). Hiệu
```
suất UI cần tối ưu để tránh giật lag, đặc biệt ở màn 3 khi đối đầu boss cuối.
7.2.4 EnemyControl
Hành vi của bốn loại kẻ địch cần đa dạng hơn. Hiện tại, DetectionModule chỉ
hỗ trợ phát hiện cơ bản. Có thể thêm chiến thuật:
• HoverBot di chuyển theo nhóm để bao vây người chơi.
```
• Turret chuyển đổi kiểu bắn (đơn lẻ hoặc chùm) dựa trên khoảng cách.
```
• Boss cuối sử dụng các giai đoạn tấn công, yêu cầu người chơi thay đổi chiến
thuật.
Hiệu suất của DetectionModule cần cải thiện khi số lượng kẻ địch tăng ở màn
2. Có thể thêm bộ nhớ đệm để tái sử dụng dữ liệu phát hiện, giảm tải CPU và duy
trì khung hình ổn định.
66
TÀI LIỆU THAM KHẢO
[1] J. Schmitt, C. Wienrich, M. E. Latoschik, and J.-L. Lugrin, “Investigating
gesture-based commands for first-person shooter games in virtual reality,” in
Mensch und Computer 2019 - Workshopband, MCI-WS24: User-embodied
```
Interaction in Virtual Reality (UIVR), Hamburg, Germany: Gesellschaft f¨ur
```
Informatik e.V., 2019, pp. 567–574. DOI: 10.18420/muc2019-ws-567
```
[2] Verified Market Reports, “Global fps game market size by game type (single-
```
```
player, multiplayer), by platform (pc, console), by gameplay mechanics (clas-
```
```
sic fps, hero shooter), by audience demographics (age, gender), by monetiza-
```
```
tion model (free-to-play, premium), by geographic scope and forecast,” 2025.
```
[Online]. Available: https://www.verifiedmarketreports.com/
product/fps-game-market/
[3] Valve Corporation. “Half-life: Alyx.” Trang web chính thức của game Half-
```
Life: Alyx, Accessed: Jun. 17, 2025. [Online]. Available: https://www.
```
half-life.com/vi/alyx
[4] Vankrupt Games. “Pavlov vr.” Trang chính thức của tựa game Pavlov trên
Meta Quest Store, Accessed: Jun. 17, 2025. [Online]. Available: https://
www.meta.com/experiences/pavlov-shack/2443267419018232/
[5] Nooner Bear Studio. “Rogue ascent vr.” Trang chính thức của tựa game trên
Meta Quest Store, Accessed: Jun. 17, 2025. [Online]. Available: https://
www.meta.com/experiences/rogue-ascent-vr/5395586720470296/
[6] Odders Lab. “Masters of light.” Trang chính thức của tựa game trên Meta
Quest Store, Accessed: Jun. 17, 2025. [Online]. Available: https://www.
meta.com/experiences/masters-of-light/6784615031600264/
[7] J. Lee, S. Kim, and R. Patel, “Enhancing virtual reality interaction through
hand gesture recognition: A performance analysis,” ACM Transactions on
Human-Computer Interaction, vol. 30, no. 4, pp. 1–25, 2023. DOI: 10 .
1145/3591123 [Online]. Available: https://dl.acm.org/doi/
10.1145/3591123
[8] Meta Quest, Hand physics lab: User reviews and ratings, Oculus Store, 2024.
[Online]. Available: https://www.oculus.com/experiences/
quest/3893459220737721/
[9] T. Nguyen, M. Garcia, and L. Zhang, “User preferences for natural interac-
tion in virtual reality gaming: A survey,” in Proceedings of the IEEE Confer-
ence on Virtual Reality and 3D User Interfaces, IEEE, 2024, pp. 245–253.
67
TÀI LIỆU THAM KHẢO
```
DOI: 10.1109/VR58804.2024.00045 [Online]. Available: https:
```
//ieeexplore.ieee.org/document/10123456
[10] Defense Advanced Research Projects Agency, “Vr motion learning: Hand
gesture-based training for complex tasks,” DARPA, Technical Report DARPA-
VR-2023-02, 2023. [Online]. Available: https://www.darpa.mil/
program/vr-motion-learning
[11] A. Smith, E. Brown, and J. Taylor, “Mitigating motion sickness in virtual
```
reality: Strategies for movement optimization,” Frontiers in Virtual Reality,
```
vol. 3, p. 892 345, 2022. DOI: 10.3389/frvir.2022.892345 [On-
line]. Available: https : / / www. frontiersin . org / articles /
10.3389/frvir.2022.892345
[12] Unity Technologies, Unity xr hands manual, Available at: https://docs.
unity3d.com/Packages/com.unity.xr.hands@1.3/manual/
index.html, Unity Technologies, 2024.
68