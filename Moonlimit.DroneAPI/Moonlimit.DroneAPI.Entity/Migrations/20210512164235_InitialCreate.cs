using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Moonlimit.DroneAPI.Entity.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DroneCom");

            migrationBuilder.CreateTable(
                name: "board_network",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    ss_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    encryption = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    ip_address = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    subnet_mask = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<long>(type: "bigint", nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    company_account_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_board_network", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company_accounts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    is_trial = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    set_active = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drone_commands",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    drone_id = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    action = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drone_commands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drone_network_settings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    ss_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    use_dhcp = table.Column<bool>(type: "boolean", nullable: false),
                    encryption = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    ip_address = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    subnet_mask = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    router = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    dns_hostname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    order = table.Column<short>(type: "smallint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    company_account_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drone_network_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drone_onvif_settings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    user_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    service_port = table.Column<int>(type: "integer", nullable: false),
                    listening_address = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    company_account_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drone_onvif_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "object_detections",
                schema: "DroneCom",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    drone_id = table.Column<long>(type: "bigint", nullable: false),
                    mission_id = table.Column<long>(type: "bigint", nullable: false),
                    tag_number = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    location = table.Column<Point>(type: "geography", nullable: true),
                    object_type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    object_id = table.Column<int>(type: "integer", nullable: false),
                    image = table.Column<byte[]>(type: "bytea", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_object_detections", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patrol_configs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    follow_distance = table.Column<float>(type: "real", nullable: false),
                    relative_altitude = table.Column<float>(type: "real", nullable: false),
                    person_score_threshold = table.Column<float>(type: "real", nullable: false),
                    vehicle_score_threshold = table.Column<float>(type: "real", nullable: false),
                    target_lost_timeouts = table.Column<float>(type: "real", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patrol_configs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "planned_routes",
                schema: "DroneCom",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    drone_id = table.Column<long>(type: "bigint", nullable: false),
                    waypoints_json = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_planned_routes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status_reports",
                schema: "DroneCom",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    drone_id = table.Column<long>(type: "bigint", nullable: false),
                    last_report_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    armed = table.Column<bool>(type: "boolean", nullable: false),
                    disabled = table.Column<bool>(type: "boolean", nullable: false),
                    failsafe = table.Column<bool>(type: "boolean", nullable: false),
                    battery = table.Column<float>(type: "real", nullable: false),
                    drone_state_type = table.Column<int>(type: "integer", nullable: false),
                    drone_action_type = table.Column<int>(type: "integer", nullable: false),
                    drone_action_complete = table.Column<bool>(type: "boolean", nullable: false),
                    mission_state_type = table.Column<int>(type: "integer", nullable: false),
                    gps_quality = table.Column<int>(type: "integer", nullable: false),
                    location = table.Column<Point>(type: "geography", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_status_reports", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    first_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    last_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    user_name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    is_admin_role = table.Column<bool>(type: "boolean", nullable: false),
                    roles = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    company_account_id = table.Column<int>(type: "integer", nullable: false),
                    code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    company_account_id1 = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_company_accounts_company_account_id1",
                        column: x => x.company_account_id1,
                        principalTable: "company_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "drones",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    tag_number = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    owner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    platform_code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    onboard_code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    assigned_mission_id = table.Column<int>(type: "integer", nullable: true),
                    assigned_mission_id1 = table.Column<long>(type: "bigint", nullable: true),
                    token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    onvif_settings_id = table.Column<int>(type: "integer", nullable: true),
                    onvif_settings_id1 = table.Column<long>(type: "bigint", nullable: true),
                    board_network_id = table.Column<int>(type: "integer", nullable: true),
                    board_network_id1 = table.Column<long>(type: "bigint", nullable: true),
                    last_online = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status_code = table.Column<int>(type: "integer", nullable: false),
                    flight_status_code = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    company_account_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drones", x => x.id);
                    table.ForeignKey(
                        name: "fk_drones_board_network_board_network_id1",
                        column: x => x.board_network_id1,
                        principalTable: "board_network",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_drones_drone_onvif_settings_onvif_settings_id1",
                        column: x => x.onvif_settings_id1,
                        principalTable: "drone_onvif_settings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "drone_drone_network_settings",
                columns: table => new
                {
                    drones_id = table.Column<long>(type: "bigint", nullable: false),
                    networks_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drone_drone_network_settings", x => new { x.drones_id, x.networks_id });
                    table.ForeignKey(
                        name: "fk_drone_drone_network_settings_drone_network_settings_network",
                        column: x => x.networks_id,
                        principalTable: "drone_network_settings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_drone_drone_network_settings_drones_drones_id",
                        column: x => x.drones_id,
                        principalTable: "drones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "geo_points",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    coordinates = table.Column<Point>(type: "geography", nullable: true),
                    geo_area_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_geo_points", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "missions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    mission_area_id = table.Column<int>(type: "integer", nullable: false),
                    type_code = table.Column<int>(type: "integer", nullable: false),
                    target_altitude = table.Column<float>(type: "real", nullable: false),
                    mission_area_id1 = table.Column<long>(type: "bigint", nullable: true),
                    drone_bases = table.Column<List<Point>>(type: "geometry[]", nullable: true),
                    patrol_config_id = table.Column<int>(type: "integer", nullable: false),
                    patrol_config_id1 = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    company_account_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_missions", x => x.id);
                    table.ForeignKey(
                        name: "fk_missions_patrol_configs_patrol_config_id1",
                        column: x => x.patrol_config_id1,
                        principalTable: "patrol_configs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "geo_areas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    kind = table.Column<int>(type: "integer", nullable: false),
                    mission_id = table.Column<long>(type: "bigint", nullable: true),
                    mission_id1 = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    test_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_geo_areas", x => x.id);
                    table.ForeignKey(
                        name: "fk_geo_areas_missions_mission_id",
                        column: x => x.mission_id,
                        principalTable: "missions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_geo_areas_missions_mission_id1",
                        column: x => x.mission_id1,
                        principalTable: "missions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_company_accounts_deleted_at",
                table: "company_accounts",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_drone_commands_deleted_at",
                table: "drone_commands",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_drone_drone_network_settings_networks_id",
                table: "drone_drone_network_settings",
                column: "networks_id");

            migrationBuilder.CreateIndex(
                name: "ix_drone_network_settings_deleted_at",
                table: "drone_network_settings",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_drone_onvif_settings_deleted_at",
                table: "drone_onvif_settings",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_drones_assigned_mission_id1",
                table: "drones",
                column: "assigned_mission_id1");

            migrationBuilder.CreateIndex(
                name: "ix_drones_board_network_id1",
                table: "drones",
                column: "board_network_id1");

            migrationBuilder.CreateIndex(
                name: "ix_drones_deleted_at",
                table: "drones",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_drones_name",
                table: "drones",
                column: "name")
                .Annotation("Npgsql:IndexInclude", new[] { "tag_number" });

            migrationBuilder.CreateIndex(
                name: "ix_drones_onvif_settings_id1",
                table: "drones",
                column: "onvif_settings_id1");

            migrationBuilder.CreateIndex(
                name: "ix_drones_token",
                table: "drones",
                column: "token");

            migrationBuilder.CreateIndex(
                name: "ix_drones_user_id",
                table: "drones",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_geo_areas_deleted_at",
                table: "geo_areas",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_geo_areas_mission_id",
                table: "geo_areas",
                column: "mission_id");

            migrationBuilder.CreateIndex(
                name: "ix_geo_areas_mission_id1",
                table: "geo_areas",
                column: "mission_id1");

            migrationBuilder.CreateIndex(
                name: "ix_geo_points_deleted_at",
                table: "geo_points",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_geo_points_geo_area_id",
                table: "geo_points",
                column: "geo_area_id");

            migrationBuilder.CreateIndex(
                name: "ix_missions_deleted_at",
                table: "missions",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_missions_mission_area_id1",
                table: "missions",
                column: "mission_area_id1");

            migrationBuilder.CreateIndex(
                name: "ix_missions_patrol_config_id1",
                table: "missions",
                column: "patrol_config_id1");

            migrationBuilder.CreateIndex(
                name: "ix_missions_user_id",
                table: "missions",
                column: "user_id")
                .Annotation("Npgsql:IndexInclude", new[] { "name" });

            migrationBuilder.CreateIndex(
                name: "ix_object_detections_deleted_at",
                schema: "DroneCom",
                table: "object_detections",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_patrol_configs_deleted_at",
                table: "patrol_configs",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_planned_routes_deleted_at",
                schema: "DroneCom",
                table: "planned_routes",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_status_reports_deleted_at",
                schema: "DroneCom",
                table: "status_reports",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_users_company_account_id1",
                table: "users",
                column: "company_account_id1");

            migrationBuilder.CreateIndex(
                name: "ix_users_deleted_at",
                table: "users",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_users_user_name",
                table: "users",
                column: "user_name")
                .Annotation("Npgsql:IndexInclude", new[] { "password" });

            migrationBuilder.AddForeignKey(
                name: "fk_drones_missions_assigned_mission_id1",
                table: "drones",
                column: "assigned_mission_id1",
                principalTable: "missions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_geo_points_geo_areas_geo_area_id",
                table: "geo_points",
                column: "geo_area_id",
                principalTable: "geo_areas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_missions_geo_areas_mission_area_id1",
                table: "missions",
                column: "mission_area_id1",
                principalTable: "geo_areas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_geo_areas_missions_mission_id",
                table: "geo_areas");

            migrationBuilder.DropForeignKey(
                name: "fk_geo_areas_missions_mission_id1",
                table: "geo_areas");

            migrationBuilder.DropTable(
                name: "drone_commands");

            migrationBuilder.DropTable(
                name: "drone_drone_network_settings");

            migrationBuilder.DropTable(
                name: "geo_points");

            migrationBuilder.DropTable(
                name: "object_detections",
                schema: "DroneCom");

            migrationBuilder.DropTable(
                name: "planned_routes",
                schema: "DroneCom");

            migrationBuilder.DropTable(
                name: "status_reports",
                schema: "DroneCom");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "drone_network_settings");

            migrationBuilder.DropTable(
                name: "drones");

            migrationBuilder.DropTable(
                name: "company_accounts");

            migrationBuilder.DropTable(
                name: "board_network");

            migrationBuilder.DropTable(
                name: "drone_onvif_settings");

            migrationBuilder.DropTable(
                name: "missions");

            migrationBuilder.DropTable(
                name: "geo_areas");

            migrationBuilder.DropTable(
                name: "patrol_configs");
        }
    }
}
